<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
  <html>
    <body>
      <h1 style="background-color: teal; color: white; ont-size: 24pt; text-align: center; letter-spacing: 1.0em">
       My orders
      </h1>
      <table border="1">
        <xsl:for-each select="Orders/Order">
            <tr style="font-size: 12pt; font-family: verdana; font-weight: bold">
              <td style="text-align: center" colspan ="3">Id Заказа</td>
            </tr>
            <tr styls="font-size: 10pt; font-faraily: verdana; font-weight: bold">
              <td align="center" colspan ="3">
                <xsl:value-of select="Order"/>
                <xsl:value-of select="@id"/>
              </td>
            </tr>
          <tr style="font-size: 10pt; font-family: verdana; font-weight: bold">
            <td style="text-align: center">Id товара</td>
            <td style="text-align: center">Название товара</td>
            <td style="text-align: center">Цена товара</td>
          </tr>
          <xsl:for-each select="Product">
            <tr styls="font-size: 10pt; font-faraily: verdana">
              <td align="left">
                <xsl:value-of select="Product"/>
                <xsl:value-of select="@productId"/>
              </td>
              <td align="left">
                <xsl:value-of select="productName" />
              </td>
              <td align="left">
                <xsl:value-of select="productPrice" />
              </td>
            </tr>
          </xsl:for-each>
          <tr style="font-size: 12pt; font-family: verdana; font-weight: bold">
            <td style="text-align: center" colspan ="3" height="15px"></td>
          </tr>
        </xsl:for-each>
      </table>
    </body>
    </html>
</xsl:template>
</xsl:stylesheet> 
