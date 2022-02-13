using System.Text;

namespace ShennonHaffman;

public static class Program
{
    public static void Main()
    {
        var tests = new[]
        {
            "Аникеенко",
            "Егор",
            "оенинАек",
            "рЕго",
            "11010000 10010101 11010000 10110011 11010000 10111110 11010001 10000000", // Егор
            "11010000 10010000 11010000 10111101 11010000 10111000 11010000 10111010 11010000 10110101 11010000 10110101 11010000 10111101 11010000 10111010 11010000 10111110" // Аникеенко
        };
        foreach (var str in tests)
        {
            byte[] originalData = Encoding.Default.GetBytes(str);
            uint originalDataSize = (uint)str.Length;
            byte[] compressedData = new byte[GetOutputSize(originalDataSize)];
            byte[] decompressedData = new byte[originalDataSize];

            int compressedDataSize = Compress(originalData, compressedData, originalDataSize);
            Decompress(compressedData, ref decompressedData, (uint)compressedDataSize, originalDataSize);

            Console.WriteLine($"Original data: {str}");
            Console.WriteLine($"Original data size: {originalDataSize}");
            Console.WriteLine($"Compressed data: {Encoding.UTF8.GetString(compressedData)}");
            Console.WriteLine($"Compressed data size: {compressedDataSize}");
            Console.WriteLine($"Decompressed data: {Encoding.UTF8.GetString(originalData)}");
            Console.WriteLine();
        }

    }

    private const int MAX_TREE_NODES = 511;

    public class TreeNode
    {
        public TreeNode ChildA;
        public TreeNode ChildB;
        public int Symbol;
    }


    private static uint readBit(ref BitStream stream)
    {
        byte[] buffer = stream.BytePointer;
        uint bit = stream.BitPosition;
        uint x = (uint)(Convert.ToBoolean(buffer[stream.Index] & (1 << (int)(7 - bit))) ? 1 : 0);
        bit = (bit + 1) & 7;

        if (!Convert.ToBoolean(bit))
        {
            ++stream.Index;
        }

        stream.BitPosition = bit;

        return x;
    }

    private static uint read8Bits(ref BitStream stream)
    {
        byte[] buffer = stream.BytePointer;
        uint bit = stream.BitPosition;
        uint x = (uint)((buffer[stream.Index] << (int)bit) | (buffer[stream.Index + 1] >> (int)(8 - bit)));
        ++stream.Index;

        return x;
    }

    private static TreeNode recoverTree(TreeNode[] nodes, ref BitStream stream, ref uint nodeNumber)
    {
        TreeNode thisNode;

        thisNode = nodes[nodeNumber];
        nodeNumber = nodeNumber + 1;

        thisNode.Symbol = -1;
        thisNode.ChildA = null;
        thisNode.ChildB = null;

        if (Convert.ToBoolean(readBit(ref stream)))
        {
            thisNode.Symbol = (int)read8Bits(ref stream);
            return thisNode;
        }

        if (Convert.ToBoolean(readBit(ref stream)))
        {
            thisNode.ChildA = recoverTree(nodes, ref stream, ref nodeNumber);
        }

        if (Convert.ToBoolean(readBit(ref stream)))
        {
            thisNode.ChildB = recoverTree(nodes, ref stream, ref nodeNumber);
        }

        return thisNode;
    }

    public static void Decompress(byte[] input, ref byte[] output, uint inputSize, uint outputSize)
    {
        TreeNode[] nodes = new TreeNode[MAX_TREE_NODES];

        for (int counter = 0; counter < nodes.Length; counter++)
        {
            nodes[counter] = new TreeNode();
        }

        TreeNode root, node;
        BitStream stream = new BitStream();
        uint i, nodeCount;
        byte[] buffer;

        if (inputSize < 1) return;

        initBitStream(ref stream, input);

        nodeCount = 0;
        root = recoverTree(nodes, ref stream, ref nodeCount);
        buffer = output;

        for (i = 0; i < outputSize; ++i)
        {
            node = root;

            while (node.Symbol < 0)
            {
                if (Convert.ToBoolean(readBit(ref stream)))
                    node = node.ChildB;
                else
                    node = node.ChildA;
            }

            buffer[i] = (byte)node.Symbol;
        }
    }
    public class BitStream
    {
        public byte[] BytePointer;
        public uint BitPosition;
        public uint Index;
    }

    public struct Symbol
    {
        public uint Sym;
        public uint Count;
        public uint Code;
        public uint Bits;
    }

    private static uint GetOutputSize(uint originalDataSize)
    {
        return originalDataSize * (101 / 100) + 384;
    }

    private static void initBitStream(ref BitStream stream, byte[] buffer)
    {
        stream.BytePointer = buffer;
        stream.BitPosition = 0;
    }

    private static void writeBits(ref BitStream stream, uint x, uint bits)
    {
        byte[] buffer = stream.BytePointer;
        uint bit = stream.BitPosition;
        uint mask = (uint)(1 << (int)(bits - 1));

        for (uint count = 0; count < bits; ++count)
        {
            buffer[stream.Index] = (byte)((buffer[stream.Index] & (0xff ^ (1 << (int)(7 - bit)))) + ((Convert.ToBoolean(x & mask) ? 1 : 0) << (int)(7 - bit)));
            x <<= 1;
            bit = (bit + 1) & 7;

            if (!Convert.ToBoolean(bit))
            {
                ++stream.Index;
            }
        }

        stream.BytePointer = buffer;
        stream.BitPosition = bit;
    }

    private static void histogram(byte[] input, Symbol[] sym, uint size)
    {
        Symbol temp;
        int i, swaps;
        int index = 0;

        for (i = 0; i < 256; ++i)
        {
            sym[i].Sym = (uint)i;
            sym[i].Count = 0;
            sym[i].Code = 0;
            sym[i].Bits = 0;
        }

        for (i = (int)size; Convert.ToBoolean(i); --i, ++index)
        {
            sym[input[index]].Count++;
        }

        do
        {
            swaps = 0;

            for (i = 0; i < 255; ++i)
            {
                if (sym[i].Count < sym[i + 1].Count)
                {
                    temp = sym[i];
                    sym[i] = sym[i + 1];
                    sym[i + 1] = temp;
                    swaps = 1;
                }
            }
        } while (Convert.ToBoolean(swaps));
    }

    private static void makeTree(Symbol[] sym, ref BitStream stream, uint code, uint bits, uint first, uint last)
    {
        uint i, size, sizeA, sizeB, lastA, firstB;

        if (first == last)
        {
            writeBits(ref stream, 1, 1);
            writeBits(ref stream, sym[first].Sym, 8);
            sym[first].Code = code;
            sym[first].Bits = bits;
            return;
        }
        else
        {
            writeBits(ref stream, 0, 1);
        }

        size = 0;

        for (i = first; i <= last; ++i)
        {
            size += sym[i].Count;
        }

        sizeA = 0;

        for (i = first; sizeA < ((size + 1) >> 1) && i < last; ++i)
        {
            sizeA += sym[i].Count;
        }

        if (sizeA > 0)
        {
            writeBits(ref stream, 1, 1);

            lastA = i - 1;

            makeTree(sym, ref stream, (code << 1) + 0, bits + 1, first, lastA);
        }
        else
        {
            writeBits(ref stream, 0, 1);
        }

        sizeB = size - sizeA;

        if (sizeB > 0)
        {
            writeBits(ref stream, 1, 1);

            firstB = i;

            makeTree(sym, ref stream, (code << 1) + 1, bits + 1, firstB, last);
        }
        else
        {
            writeBits(ref stream, 0, 1);
        }
    }

    public static int Compress(byte[] input, byte[] output, uint inputSize)
    {
        Symbol[] sym = new Symbol[256];
        Symbol temp;
        BitStream stream = new BitStream();
        uint i, totalBytes, swaps, symbol, lastSymbol;

        if (inputSize < 1)
            return 0;

        initBitStream(ref stream, output);
        histogram(input, sym, inputSize);

        for (lastSymbol = 255; sym[lastSymbol].Count == 0; --lastSymbol) ;

        if (lastSymbol == 0)
            ++lastSymbol;

        makeTree(sym, ref stream, 0, 0, 0, lastSymbol);

        do
        {
            swaps = 0;

            for (i = 0; i < 255; ++i)
            {
                if (sym[i].Sym > sym[i + 1].Sym)
                {
                    temp = sym[i];
                    sym[i] = sym[i + 1];
                    sym[i + 1] = temp;
                    swaps = 1;
                }
            }
        } while (Convert.ToBoolean(swaps));

        for (i = 0; i < inputSize; ++i)
        {
            symbol = input[i];
            writeBits(ref stream, sym[symbol].Code, sym[symbol].Bits);
        }

        totalBytes = stream.Index;

        if (stream.BitPosition > 0)
        {
            ++totalBytes;
        }

        return (int)totalBytes;
    }

}