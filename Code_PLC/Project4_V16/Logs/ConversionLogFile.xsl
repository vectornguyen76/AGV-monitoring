<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">
	<xsl:output method="html"/>
	
	<!-- used for output formatting: -->
	<xsl:variable name="NewLine"><br /></xsl:variable>
	<xsl:variable name="Blank">
		<xsl:text> </xsl:text>
	</xsl:variable>
	
	<xsl:variable name="ProjectName" select="/LogFile/@projectName"/>
	<xsl:variable name="TypeColHeader" select="/LogFile/@typeText"/>
	<xsl:variable name="MessageColHeader" select="/LogFile/@messageText"/>
	<xsl:variable name="TimeColHeader" select="/LogFile/@timeText"/>
	<xsl:variable name="vendor" select="system-property('xsl:vendor')"/>
	
	<!-- start on document root: -->
	<xsl:template match="/LogFile">
		<html>
			<xsl:value-of select="$NewLine"/>
			<head>
				<title>Conversion log file</title>
				<style type="text/css">
          .TitleText               { font-family:'Siemens TIA Portal Basic'; font-size:15pt; font-weight: bold; color: #59717d; line-height:23px; }
          .Text                    { font-family:'Siemens TIA Portal Basic'; font-size:10pt; font-weight: bold; color: black;   line-height:26px; }
          .TableHeader             { font-family:'Siemens TIA Portal Basic'; font-size:10pt; font-weight: bold; height: 15pt; text-indent: 6px; border-style: solid; border-color: #8ca3b0; border-width: 0.5pt 0.5pt 0.5pt 0; font-weight: bold; background-color:#b6c5cf; }
          .TableHeader1            { font-family:'Siemens TIA Portal Basic'; font-size:10pt; font-weight: bold; height: 15pt; text-indent: 6px; border-style: solid; border-color: #bfbfbf; border-width: 0 0.5pt 0.5pt 0; font-weight: bold; background-color:#d4dbde; }
          .TableHeader2            { font-family:'Siemens TIA Portal Basic'; font-size:10pt; font-weight: bold; height: 15pt; text-indent: 6px; border-style: solid; border-color: #bfbfbf; border-width: 0 0.5pt 0.5pt 0; font-weight: bold; background-color:#e7ebed; }
          .TableContent            { font-family:'Siemens TIA Portal Basic'; font-size:10pt; height: 15pt; text-indent: 6px; border-style: solid; border-color: #bfbfbf; border-width: 0 0.5pt 0.5pt 0; }
          .TableGraphicActionRequest    { filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(src='ICO_PE_InfoActionRequest.png',    sizingMethod='center'); background:none; align:center; width:16px }
          .TableGraphicDecision         { filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(src='ICO_PE_InfoDecision.png',         sizingMethod='center'); background:none; align:center; width:16px }
          .TableGraphicDecisionCritical { filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(src='ICO_PE_InfoDecisionCritical.png', sizingMethod='center'); background:none; align:center; width:16px }
          .TableGraphicError            { filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(src='ICO_PE_InfoError.png',            sizingMethod='center'); background:none; align:center; width:16px }
          .TableGraphicErrorCritical    { filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(src='ICO_PE_InfoErrorCritical.png',    sizingMethod='center'); background:none; align:center; width:16px }
          .TableGraphicInformation      { filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(src='ICO_PE_InfoInformation.png',      sizingMethod='center'); background:none; align:center; width:16px }
          .TableGraphicInputRequired    { filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(src='ICO_PE_InfoInputRequired.png',    sizingMethod='center'); background:none; align:center; width:16px }
          .TableGraphicSuccess          { filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(src='ICO_PE_InfoSuccess.png',          sizingMethod='center'); background:none; align:center; width:16px }
          .TableGraphicWarning          { filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(src='ICO_PE_InfoWarning.png',          sizingMethod='center'); background:none; align:center; width:16px }
          .TimeStampCell { font-family:'Siemens TIA Portal Basic'; font-size:9pt;  font-weight: normal; height: 18px; text-indent: 6px;}
        </style>
			</head>
			<body>
				<p class="TitleText">
					<xsl:value-of select="$ProjectName"/>
				</p>
				<xsl:value-of select="$NewLine"/>
				<table cellspacing="0" cellpadding="3" style="border-left: 1px solid #bfbfbf">
					<tr class="TableHeader">
						<td class="TableHeader" align="left" style="width: 32px; ">
							<xsl:value-of select="$TypeColHeader"/>
						</td>
						<td class="TableHeader" align="left" style="width: 648px; ">
							<xsl:value-of select="$MessageColHeader"/>
						</td>
						<td class="TableHeader" align="left" style="width: 90px">
							<xsl:value-of select="$TimeColHeader"/>
						</td>
					</tr>
					<xsl:apply-templates select="MessageCell"/>
				</table>
			</body>
		</html>
	</xsl:template>
	
	<xsl:template name="LogEntry" match="*/MessageCell">
		<tr class="TableContent">
			<td align="center" class="TableContent">
				<p>
				  <img class="TableGraphic">
					  <xsl:attribute name="alt">
						  <xsl:value-of select="@MessageClass"/>
					  </xsl:attribute>
					  <xsl:attribute name="src">
						  <xsl:choose>
							  <xsl:when test="@MessageClass = 'Error'">ICO_PE_InfoError.png</xsl:when>
							  <xsl:when test="@MessageClass = 'ErrorCritical'">ICO_PE_InfoErrorCritical.png</xsl:when>
							  <xsl:when test="@MessageClass = 'Information'">ICO_PE_InfoInformation.png</xsl:when>
							  <xsl:when test="@MessageClass = 'Success'">ICO_PE_InfoSuccess.png</xsl:when>
							  <xsl:when test="@MessageClass = 'Warning'">ICO_PE_InfoWarning.png</xsl:when>
							  <xsl:otherwise>TableContent</xsl:otherwise>
						  </xsl:choose>
					  </xsl:attribute>
				  </img>
				</p>
			</td>
			<td align="left" class="TableContent">
				<xsl:call-template name="FilterText">
					<xsl:with-param name="Text" select="Text/@FeedbackText"/>
				</xsl:call-template>
				<img width="1px" src="ICO_PE_Empty.png"/>
			</td>
			<td align="left" class="TableContent">
				<xsl:value-of select="@Timestamp"/>
				<img width="1px" src="ICO_PE_Empty.png"/>
			</td>
		</tr>
	</xsl:template>
	
	<xsl:template name="FilterText">
		<xsl:param name="Text"/>
		<xsl:choose>
			<xsl:when test="contains($Text, '&lt;!--')">				
				<xsl:call-template name="FilterText">
					<xsl:with-param name="Text" select="concat(substring-before($Text, '&lt;!--'), substring-after($Text, '--&gt;'))"/>
				</xsl:call-template>
			</xsl:when>
			<xsl:otherwise>
				<xsl:value-of select="$Text"/>
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>
		
</xsl:stylesheet>
