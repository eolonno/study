using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;

namespace ЛР__12
{
    public static class Reflector
    {
        public static string Path = "D:\\Учеба\\ООП\\ЛР №12\\";
        public static void AssemblyName(object obj)
        {
            Type type = obj.GetType();
            string Info = "Имя сборки: " + type.Name + '\n' + "--------------------------\n";
            File.AppendAllText(Path + type.Name + ".txt", Info);
        }
        public static void PublicContructors(object obj)
        {
            Type type = obj.GetType();
            string Info = "Есть ли публичные конструкторы: ";
            var ConstructorInfo = type.GetConstructors();
            if (ConstructorInfo.Length > 0)
                Info += "да\n";
            else
                Info += "нет\n";
            Info += "--------------------------\n";
            File.AppendAllText(Path + type.Name + ".txt", Info);
        }
        public static List<string> PublicMethods(object obj)
        {
            string PublicMethodsString = "Публичные методы: \n";
            Type type = obj.GetType();
            List<string> PublicMethodsList = new List<string>();

            var AllMethods = type.GetMethods();
            foreach (var MI in AllMethods)
            {
                PublicMethodsList.Add(MI.Name);
                PublicMethodsString += MI.Name + "\n";
            }

            PublicMethodsString += "--------------------------\n";
            if (PublicMethodsList.Count == 0)
                File.AppendAllText(Path + type.Name + ".txt", "Публичные методы: нет\n" +
                    "--------------------------\n");
            else
                File.AppendAllText(Path + type.Name + ".txt", PublicMethodsString);
            return PublicMethodsList;
        }
        public static List<string> FieldsAndPropertiesInfo(object obj)
        {
            Type type = obj.GetType();
            string Info = "Поля:\n";
            List<string> FieldsAndProperties = new List<string>();

            var FieldsArr = type.GetFields();

            foreach (FieldInfo FI in FieldsArr)
            {
                FieldsAndProperties.Add(FI.Name);
                Info += FI.Name + '\n';
            }

            if (Info == "Поля:\n")
                Info = "Поля: нет\n";
            Info += "--------------------------\n";

            var Properties = type.GetProperties();

            Info += "Свойства: \n";
            var InfoFields = Info;
            foreach (var PI in Properties)
            {
                FieldsAndProperties.Add(PI.Name);
                Info += PI.Name + '\n';
            }

            if (Info == InfoFields)
                Info = InfoFields.Remove(InfoFields.LastIndexOf('\n')) + " нет";

            Info += "--------------------------\n";
            File.AppendAllText(Path + type.Name + ".txt", Info);
            return FieldsAndProperties;
        }
        public static List<string> Interfaces(object obj)
        {
            Type type = obj.GetType();
            string Info = "Реализованные интерфейсы:\n";
            List<string> InterfacesList = new List<string>();

            var Interfaces = type.GetInterfaces();
            foreach (var I in Interfaces)
            {
                InterfacesList.Add(I.Name);
                Info += I.Name + '\n';
            }

            Info += "--------------------------\n";
            if (InterfacesList.Count == 0)
                File.AppendAllText(Path + type.Name + ".txt", "Реализованные интерфейсы: нет\n--------------------------\n");
            else
                File.AppendAllText(Path + type.Name + ".txt", Info);
            return InterfacesList;
        }
        public static void MethodsByParameterType(object obj, Type Parameter)
        {
            Type type = obj.GetType();
            string Info = "Методы с типом параметра " + Parameter.Name + ":\n";
            string InfoStart = Info;

            var AllMethods = type.GetMethods();
            foreach (var MI in AllMethods)
            {
                var MIParameters = MI.GetParameters();
                foreach (var PI in MIParameters)
                {
                    if (PI.ParameterType == Parameter)
                    {
                        Info += MI.Name + '\n';
                        break;
                    }
                }
            }

            Info += "--------------------------\n";
            if (InfoStart != Info)
                File.AppendAllText(Path + type.Name + ".txt", Info);
            else
                File.AppendAllText(Path + type.Name + ".txt", "Методы с типом параметра " + Parameter.Name + ": нет" + "--------------------------\n");
        }
        public static object? Invoke(object obj, string MethodName, object?[]? Parameters)
        {
            Type type = obj.GetType();
            var Method = type.GetMethod(MethodName);
            var Result = Method.Invoke(obj, Parameters);
            return Result;
        }
        public static object? Create<T>(object?[]? Params)
        {
            Type type = typeof(T);
            var Constructors = type.GetConstructors();
            var Parameters = Constructors[0].GetParameters();
            object? Result = null;
            
            if (Params == null)
            {
                foreach (var Constructor in Constructors)
                {
                    if (Constructor.GetParameters().Length == 0)
                    {
                        Result = Constructor.Invoke(null);
                        break;
                    }
                }
            }
            else
            {
                foreach (var Constructor in Constructors)
                {
                    if (Constructor.GetParameters().Length == Params.Length)
                    {
                        Result = Constructor.Invoke(Params);
                        break;
                    }
                }
            }
            return Result;
        }
    }
}
