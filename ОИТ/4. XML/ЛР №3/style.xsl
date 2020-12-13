<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
<html>
<body>
 <table border="1">
	 <tr>
		 <th style="text-align:center">Название вуза</th>
		 <th style="text-align:center">Проходные баллы</th>
		 <th style="text-align:center">План приема</th>
		 <th style="text-align:center">Город</th>
	</tr>
	<xsl:for-each select="in/info">
 		<tr>
			<td style="text-align:center; border: solid black 1px; margin: 0 20% 0 20%; padding: 10px;"><xsl:value-of select="university"/></td>
			<td style="text-align:center; border: solid black 1px; margin: 0 20% 0 20%; padding: 10px;"><xsl:value-of select="points"/></td>
			<td style="text-align:center; border: solid black 1px; margin: 0 20% 0 20%; padding: 10px;"><xsl:value-of select="plan"/></td>
			<td style="text-align:center; border: solid black 1px; margin: 0 20% 0 20%; padding: 10px;"><xsl:value-of select="city"/></td>
 		</tr>
	</xsl:for-each>
 </table>
</body>
</html>
</xsl:template>
</xsl:stylesheet>
