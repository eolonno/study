<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
<html>
<body>
 <table border="1">
	 <tr>
		 <th style="text-align:center">ФИО</th>
		 <th style="text-align:center">Оценка</th>
		 <th style="text-align:center">Год рождения</th>
	</tr>
	
	<xsl:for-each select="in/info">
		<xsl:sort select="year" order="acsending"/>
 		<tr>
			<xsl:choose>
				<xsl:when test="mark > 6">
					<td style="text-align:center; border: solid black 1px; margin: 0 20% 0 20%; padding: 10px; color:green"><xsl:value-of select="FIO"/></td>
				</xsl:when>
				<xsl:otherwise>
					<td style="text-align:center; border: solid black 1px; margin: 0 20% 0 20%; padding: 10px; color:red"><xsl:value-of select="FIO"/></td>
				</xsl:otherwise>
			</xsl:choose>
			<td style="text-align:center; border: solid black 1px; margin: 0 20% 0 20%; padding: 10px;"><xsl:value-of select="mark"/></td>
			<td style="text-align:center; border: solid black 1px; margin: 0 20% 0 20%; padding: 10px;"><xsl:value-of select="year"/></td>
 		</tr>
	</xsl:for-each>
 </table>
</body>
</html>
</xsl:template>
</xsl:stylesheet>
