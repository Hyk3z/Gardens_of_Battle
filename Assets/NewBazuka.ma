//Maya ASCII 2018 scene
//Name: NewBazuka.ma
//Last modified: Fri, Jan 29, 2021 05:08:21 PM
//Codeset: 1252
requires maya "2018";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2018";
fileInfo "version" "2018";
fileInfo "cutIdentifier" "201706261615-f9658c4cfc";
fileInfo "osv" "Microsoft Windows 8 Home Premium Edition, 64-bit  (Build 9200)\n";
fileInfo "license" "student";
createNode transform -n "pCylinder1";
	rename -uid "E14A553D-4F45-14B9-7718-AF8535D6F2CB";
	setAttr ".r" -type "double3" 91.32393408305019 0 0 ;
	setAttr ".s" -type "double3" 3.0190720485971418 6.6516423792326762 3.0190720485971418 ;
createNode mesh -n "pCylinderShape1" -p "pCylinder1";
	rename -uid "43AD027F-4679-C8D6-57A1-8EA997A47A47";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.49999998509883881 0.18566732853651047 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 152 ".pt";
	setAttr ".pt[0]" -type "float3" -0.046106052 0.0075226435 0.015093779 ;
	setAttr ".pt[1]" -type "float3" -0.039220154 0.0075226435 0.028608121 ;
	setAttr ".pt[2]" -type "float3" -0.028495111 0.0075226435 0.039333161 ;
	setAttr ".pt[3]" -type "float3" -0.014980764 0.0075226435 0.046219062 ;
	setAttr ".pt[4]" -type "float3" -5.7791154e-09 0.0075226435 0.048591781 ;
	setAttr ".pt[5]" -type "float3" 0.014980753 0.0075226435 0.046219062 ;
	setAttr ".pt[6]" -type "float3" 0.028495094 0.0075226435 0.039333157 ;
	setAttr ".pt[7]" -type "float3" 0.039220124 0.0075226435 0.028608108 ;
	setAttr ".pt[8]" -type "float3" 0.046106022 0.0075226435 0.015093774 ;
	setAttr ".pt[9]" -type "float3" 0.048478737 0.0075226435 0.00011301811 ;
	setAttr ".pt[10]" -type "float3" 0.046106022 0.0075226435 -0.01486774 ;
	setAttr ".pt[11]" -type "float3" 0.039220121 0.0075226435 -0.028382068 ;
	setAttr ".pt[12]" -type "float3" 0.028495081 0.0075226435 -0.039107103 ;
	setAttr ".pt[13]" -type "float3" 0.014980751 0.0075226435 -0.045993004 ;
	setAttr ".pt[14]" -type "float3" -4.334336e-09 0.0075226435 -0.048365723 ;
	setAttr ".pt[15]" -type "float3" -0.014980757 0.0075226435 -0.045993 ;
	setAttr ".pt[16]" -type "float3" -0.028495094 0.0075226435 -0.039107103 ;
	setAttr ".pt[17]" -type "float3" -0.039220124 0.0075226435 -0.028382065 ;
	setAttr ".pt[18]" -type "float3" -0.046106022 0.0075226435 -0.014867734 ;
	setAttr ".pt[19]" -type "float3" -0.048478737 0.0075226435 0.00011301811 ;
	setAttr ".pt[20]" -type "float3" 0.12374572 0.017789526 -0.032310281 ;
	setAttr ".pt[21]" -type "float3" 0.1052644 0.017789526 -0.068581931 ;
	setAttr ".pt[22]" -type "float3" 0.076479077 0.017789526 -0.097367257 ;
	setAttr ".pt[23]" -type "float3" 0.040207431 0.017789526 -0.11584859 ;
	setAttr ".pt[24]" -type "float3" 1.5510786e-08 0.017789526 -0.12221681 ;
	setAttr ".pt[25]" -type "float3" -0.040207397 0.017789526 -0.11584858 ;
	setAttr ".pt[26]" -type "float3" -0.076479018 0.017789526 -0.097367249 ;
	setAttr ".pt[27]" -type "float3" -0.10526436 0.017789526 -0.068581872 ;
	setAttr ".pt[28]" -type "float3" -0.12374568 0.017789526 -0.032310277 ;
	setAttr ".pt[29]" -type "float3" -0.1301139 0.017789526 0.0078971349 ;
	setAttr ".pt[30]" -type "float3" -0.12374568 0.017789526 0.048104528 ;
	setAttr ".pt[31]" -type "float3" -0.10526435 0.017789526 0.084376171 ;
	setAttr ".pt[32]" -type "float3" -0.076478995 0.017789526 0.11316149 ;
	setAttr ".pt[33]" -type "float3" -0.04020739 0.017789526 0.1316428 ;
	setAttr ".pt[34]" -type "float3" 1.1633087e-08 0.017789526 0.13801102 ;
	setAttr ".pt[35]" -type "float3" 0.04020742 0.017789526 0.1316428 ;
	setAttr ".pt[36]" -type "float3" 0.076479018 0.017789526 0.11316149 ;
	setAttr ".pt[37]" -type "float3" 0.10526436 0.017789526 0.084376127 ;
	setAttr ".pt[38]" -type "float3" 0.12374568 0.017789526 0.048104528 ;
	setAttr ".pt[39]" -type "float3" 0.1301139 0.017789526 0.0078971349 ;
	setAttr ".pt[40]" -type "float3" -5.7791154e-09 0.0075226435 0.00011301811 ;
	setAttr ".pt[41]" -type "float3" 1.5510786e-08 0.017789526 0.0078971349 ;
	setAttr ".pt[42]" -type "float3" 0.13960426 -0.00049928162 -0.037463024 ;
	setAttr ".pt[43]" -type "float3" 0.11875442 -0.00049928162 -0.078383021 ;
	setAttr ".pt[44]" -type "float3" 0.086280175 -0.00049928162 -0.11085728 ;
	setAttr ".pt[45]" -type "float3" 0.045360174 -0.00049928162 -0.13170703 ;
	setAttr ".pt[46]" -type "float3" 1.7498541e-08 -0.00049928162 -0.13889144 ;
	setAttr ".pt[47]" -type "float3" -0.045360148 -0.00049928162 -0.13170703 ;
	setAttr ".pt[48]" -type "float3" -0.08628016 -0.00049928162 -0.11085727 ;
	setAttr ".pt[49]" -type "float3" -0.11875437 -0.00049928162 -0.078383006 ;
	setAttr ".pt[50]" -type "float3" -0.13960411 -0.00049928162 -0.037463009 ;
	setAttr ".pt[51]" -type "float3" -0.14678851 -0.00049928162 0.0078971367 ;
	setAttr ".pt[52]" -type "float3" -0.13960411 -0.00049928162 0.053257275 ;
	setAttr ".pt[53]" -type "float3" -0.11875436 -0.00049928162 0.094177268 ;
	setAttr ".pt[54]" -type "float3" -0.086280115 -0.00049928162 0.1266515 ;
	setAttr ".pt[59]" -type "float3" 0.11875437 -0.00049928162 0.094177268 ;
	setAttr ".pt[60]" -type "float3" 0.13960411 -0.00049928162 0.053257272 ;
	setAttr ".pt[61]" -type "float3" 0.14678851 -0.00049928162 0.0078971367 ;
	setAttr ".pt[62]" -type "float3" 0.12374572 -0.018186465 -0.032310281 ;
	setAttr ".pt[63]" -type "float3" 0.1052644 -0.018186465 -0.068581931 ;
	setAttr ".pt[64]" -type "float3" 0.076479077 -0.018186465 -0.097367257 ;
	setAttr ".pt[65]" -type "float3" 0.040207431 -0.018186465 -0.11584859 ;
	setAttr ".pt[66]" -type "float3" 1.5510786e-08 -0.018186465 -0.12221681 ;
	setAttr ".pt[67]" -type "float3" -0.040207397 -0.018186465 -0.11584858 ;
	setAttr ".pt[68]" -type "float3" -0.076479018 -0.018186465 -0.097367249 ;
	setAttr ".pt[69]" -type "float3" -0.10526436 -0.018186465 -0.068581872 ;
	setAttr ".pt[70]" -type "float3" -0.12374568 -0.018186465 -0.032310277 ;
	setAttr ".pt[71]" -type "float3" -0.1301139 -0.018186465 0.0078971349 ;
	setAttr ".pt[72]" -type "float3" -0.12374568 -0.018186465 0.048104528 ;
	setAttr ".pt[73]" -type "float3" -0.10526435 -0.018186465 0.084376171 ;
	setAttr ".pt[80]" -type "float3" 0.12374568 -0.018186465 0.048104528 ;
	setAttr ".pt[81]" -type "float3" 0.1301139 -0.018186465 0.0078971349 ;
	setAttr ".pt[82]" -type "float3" -0.086936951 0 0.028247498 ;
	setAttr ".pt[83]" -type "float3" -0.073952973 0 0.053729948 ;
	setAttr ".pt[84]" -type "float3" -0.053729989 0 0.073952936 ;
	setAttr ".pt[85]" -type "float3" -0.028247518 0 0.086936876 ;
	setAttr ".pt[86]" -type "float3" -1.0897021e-08 0 0.091410875 ;
	setAttr ".pt[87]" -type "float3" 0.028247509 0 0.086936876 ;
	setAttr ".pt[88]" -type "float3" 0.053729944 0 0.073952928 ;
	setAttr ".pt[89]" -type "float3" 0.073952928 0 0.05372994 ;
	setAttr ".pt[90]" -type "float3" 0.086936876 0 0.028247485 ;
	setAttr ".pt[91]" -type "float3" 0.091410846 0 -1.6345531e-08 ;
	setAttr ".pt[92]" -type "float3" 0.086936876 0 -0.028247518 ;
	setAttr ".pt[93]" -type "float3" 0.073952921 0 -0.053729951 ;
	setAttr ".pt[94]" -type "float3" 0.05372994 0 -0.073952936 ;
	setAttr ".pt[95]" -type "float3" 0.028247491 0 -0.086936876 ;
	setAttr ".pt[96]" -type "float3" -8.1727656e-09 0 -0.091410875 ;
	setAttr ".pt[97]" -type "float3" -0.028247515 0 -0.086936876 ;
	setAttr ".pt[98]" -type "float3" -0.053729944 0 -0.073952936 ;
	setAttr ".pt[99]" -type "float3" -0.073952928 0 -0.053729951 ;
	setAttr ".pt[100]" -type "float3" -0.086936876 0 -0.028247517 ;
	setAttr ".pt[101]" -type "float3" -0.091410846 0 -1.6345531e-08 ;
	setAttr ".pt[102]" -type "float3" 0.10269578 0.037445784 -0.033367846 ;
	setAttr ".pt[103]" -type "float3" 0.087358251 0.037445784 -0.063469432 ;
	setAttr ".pt[104]" -type "float3" 0.063469462 0.037445784 -0.087358266 ;
	setAttr ".pt[105]" -type "float3" 0.033367869 0.037445784 -0.10269575 ;
	setAttr ".pt[106]" -type "float3" 1.2872298e-08 0.037445784 -0.10798072 ;
	setAttr ".pt[107]" -type "float3" -0.033367831 0.037445784 -0.10269573 ;
	setAttr ".pt[108]" -type "float3" -0.063469402 0.037445784 -0.087358251 ;
	setAttr ".pt[109]" -type "float3" -0.087358251 0.037445784 -0.063469402 ;
	setAttr ".pt[110]" -type "float3" -0.10269581 0.037445784 -0.033367869 ;
	setAttr ".pt[111]" -type "float3" -0.10798062 0.037445784 1.9308441e-08 ;
	setAttr ".pt[112]" -type "float3" -0.10269581 0.037445784 0.033367865 ;
	setAttr ".pt[113]" -type "float3" -0.087358177 0.037445784 0.063469447 ;
	setAttr ".pt[114]" -type "float3" -0.063469402 0.037445784 0.087358251 ;
	setAttr ".pt[115]" -type "float3" -0.033367872 0.037445784 0.10269575 ;
	setAttr ".pt[116]" -type "float3" 9.6542205e-09 0.037445784 0.10798072 ;
	setAttr ".pt[117]" -type "float3" 0.033367839 0.037445784 0.10269573 ;
	setAttr ".pt[118]" -type "float3" 0.063469402 0.037445784 0.087358251 ;
	setAttr ".pt[119]" -type "float3" 0.087358251 0.037445784 0.063469447 ;
	setAttr ".pt[120]" -type "float3" 0.10269578 0.037445784 0.033367861 ;
	setAttr ".pt[121]" -type "float3" 0.10798062 0.037445784 1.9308441e-08 ;
	setAttr ".pt[122]" -type "float3" 0.11720671 -0.012022921 -0.037969697 ;
	setAttr ".pt[123]" -type "float3" 0.099702023 -0.012022921 -0.072324656 ;
	setAttr ".pt[124]" -type "float3" 0.072437696 -0.012022921 -0.099588968 ;
	setAttr ".pt[125]" -type "float3" 0.038082745 -0.012022921 -0.11709365 ;
	setAttr ".pt[126]" -type "float3" 1.4691154e-08 -0.012022921 -0.12312535 ;
	setAttr ".pt[127]" -type "float3" -0.038082752 -0.012022921 -0.11709364 ;
	setAttr ".pt[128]" -type "float3" -0.072437637 -0.012022921 -0.099588953 ;
	setAttr ".pt[129]" -type "float3" -0.099701963 -0.012022921 -0.072324626 ;
	setAttr ".pt[130]" -type "float3" -0.11720665 -0.012022921 -0.03796969 ;
	setAttr ".pt[131]" -type "float3" -0.12323833 -0.012022921 0.00011304881 ;
	setAttr ".pt[132]" -type "float3" -0.11720665 -0.012022921 0.038195796 ;
	setAttr ".pt[133]" -type "float3" -0.099701896 -0.012022921 0.072550692 ;
	setAttr ".pt[134]" -type "float3" -0.072437637 -0.012022921 0.099815026 ;
	setAttr ".pt[135]" -type "float3" -0.038082749 -0.012022921 0.11731973 ;
	setAttr ".pt[136]" -type "float3" 1.1018368e-08 -0.012022921 0.12335154 ;
	setAttr ".pt[137]" -type "float3" 0.038082756 -0.012022921 0.1173197 ;
	setAttr ".pt[138]" -type "float3" 0.072437637 -0.012022921 0.099815026 ;
	setAttr ".pt[139]" -type "float3" 0.099701963 -0.012022921 0.072550692 ;
	setAttr ".pt[140]" -type "float3" 0.11720665 -0.012022921 0.038195793 ;
	setAttr ".pt[141]" -type "float3" 0.12323833 -0.012022921 0.00011304881 ;
	setAttr ".pt[142]" -type "float3" 0.11720671 -0.034456782 -0.037969697 ;
	setAttr ".pt[143]" -type "float3" 0.099702023 -0.034456782 -0.072324656 ;
	setAttr ".pt[144]" -type "float3" 0.072437696 -0.034456782 -0.099588968 ;
	setAttr ".pt[145]" -type "float3" 0.038082745 -0.034456782 -0.11709365 ;
	setAttr ".pt[146]" -type "float3" 1.4691154e-08 -0.034456782 -0.12312535 ;
	setAttr ".pt[147]" -type "float3" -0.038082752 -0.034456782 -0.11709364 ;
	setAttr ".pt[148]" -type "float3" -0.072437637 -0.034456782 -0.099588953 ;
	setAttr ".pt[149]" -type "float3" -0.099701963 -0.034456782 -0.072324626 ;
	setAttr ".pt[150]" -type "float3" -0.11720665 -0.034456782 -0.03796969 ;
	setAttr ".pt[151]" -type "float3" -0.12323833 -0.034456782 0.00011304881 ;
	setAttr ".pt[152]" -type "float3" -0.11720665 -0.034456782 0.038195796 ;
	setAttr ".pt[153]" -type "float3" -0.099701896 -0.034456782 0.072550692 ;
	setAttr ".pt[154]" -type "float3" -0.072437637 -0.034456782 0.099815026 ;
	setAttr ".pt[155]" -type "float3" -0.038082749 -0.034456782 0.1173197 ;
	setAttr ".pt[156]" -type "float3" 1.1018368e-08 -0.034456782 0.12335154 ;
	setAttr ".pt[157]" -type "float3" 0.038082756 -0.034456782 0.1173197 ;
	setAttr ".pt[158]" -type "float3" 0.072437637 -0.034456782 0.099815026 ;
	setAttr ".pt[159]" -type "float3" 0.099701963 -0.034456782 0.072550692 ;
	setAttr ".pt[160]" -type "float3" 0.11720665 -0.034456782 0.038195793 ;
	setAttr ".pt[161]" -type "float3" 0.12323833 -0.034456782 0.00011304881 ;
createNode transform -n "pCube1";
	rename -uid "84BDC733-4493-902E-F2E1-EEAE43197521";
	setAttr ".t" -type "double3" 0 3.4518469578163971 5.0161708760519392 ;
	setAttr ".s" -type "double3" 1 1 0.36347286759245645 ;
createNode mesh -n "pCubeShape1" -p "pCube1";
	rename -uid "A2C61D26-457F-C224-B4C1-A78CC174357B";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.5 0.37499998509883881 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 8 ".pt";
	setAttr ".pt[2]" -type "float3" 0.17169863 0 0 ;
	setAttr ".pt[3]" -type "float3" -0.17169863 0 0 ;
	setAttr ".pt[4]" -type "float3" 0.17169863 0 0 ;
	setAttr ".pt[5]" -type "float3" -0.17169863 0 0 ;
	setAttr ".pt[12]" -type "float3" -0.040809922 0 0 ;
	setAttr ".pt[13]" -type "float3" 0.040809922 0 0 ;
	setAttr ".pt[14]" -type "float3" 0.040809926 0 0 ;
	setAttr ".pt[15]" -type "float3" -0.040809926 0 0 ;
createNode polySplit -n "polySplit8";
	rename -uid "4EBF973E-46A9-8752-2C9D-FEB76F6C0C1A";
	setAttr -s 5 ".e[0:4]"  0.52580702 0.52580702 0.47419301 0.47419301
		 0.52580702;
	setAttr -s 5 ".d[0:4]"  -2147483640 -2147483639 -2147483635 -2147483636 -2147483640;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyTweak -n "polyTweak2";
	rename -uid "D9E48982-438B-AF79-0215-10AFDA7B5DB4";
	setAttr ".uopa" yes;
	setAttr -s 5 ".tk";
	setAttr ".tk[2]" -type "float3" -0.23482004 0 0.41933942 ;
	setAttr ".tk[3]" -type "float3" 0.23482004 0 0.41933942 ;
	setAttr ".tk[4]" -type "float3" -0.23482004 0 -0.41933942 ;
	setAttr ".tk[5]" -type "float3" 0.23482004 0 -0.41933942 ;
createNode polySplit -n "polySplit7";
	rename -uid "793AC46E-4292-6C62-4786-A48AE3E842DA";
	setAttr -s 5 ".e[0:4]"  0.56626701 0.56626701 0.43373299 0.43373299
		 0.56626701;
	setAttr -s 5 ".d[0:4]"  -2147483644 -2147483643 -2147483639 -2147483640 -2147483644;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyCube -n "polyCube1";
	rename -uid "6538B45C-4C8C-320C-1BB9-ADB03612C966";
	setAttr ".cuv" 4;
createNode polySplit -n "polySplit6";
	rename -uid "311FCACE-4AE6-CC94-89D8-2FADA3E6A353";
	setAttr -s 21 ".e[0:20]"  0.41841501 0.41841501 0.41841501 0.41841501
		 0.41841501 0.41841501 0.41841501 0.41841501 0.41841501 0.41841501 0.41841501 0.41841501
		 0.41841501 0.41841501 0.41841501 0.41841501 0.41841501 0.41841501 0.41841501 0.41841501
		 0.41841501;
	setAttr -s 21 ".d[0:20]"  -2147483608 -2147483607 -2147483606 -2147483605 -2147483604 -2147483603 
		-2147483602 -2147483601 -2147483600 -2147483599 -2147483598 -2147483597 -2147483596 -2147483595 -2147483594 -2147483593 -2147483592 -2147483591 
		-2147483590 -2147483589 -2147483608;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit5";
	rename -uid "C759A4D9-4A23-4669-F32C-E1A379921AA6";
	setAttr -s 21 ".e[0:20]"  0.573309 0.573309 0.573309 0.573309 0.573309
		 0.573309 0.573309 0.573309 0.573309 0.573309 0.573309 0.573309 0.573309 0.573309
		 0.573309 0.573309 0.573309 0.573309 0.573309 0.573309 0.573309;
	setAttr -s 21 ".d[0:20]"  -2147483608 -2147483607 -2147483606 -2147483605 -2147483604 -2147483603 
		-2147483602 -2147483601 -2147483600 -2147483599 -2147483598 -2147483597 -2147483596 -2147483595 -2147483594 -2147483593 -2147483592 -2147483591 
		-2147483590 -2147483589 -2147483608;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit4";
	rename -uid "16EC11C3-4D31-B0FA-B750-CB9F32C7BEC0";
	setAttr -s 21 ".e[0:20]"  0.618873 0.618873 0.618873 0.618873 0.618873
		 0.618873 0.618873 0.618873 0.618873 0.618873 0.618873 0.618873 0.618873 0.618873
		 0.618873 0.618873 0.618873 0.618873 0.618873 0.618873 0.618873;
	setAttr -s 21 ".d[0:20]"  -2147483608 -2147483607 -2147483606 -2147483605 -2147483604 -2147483603 
		-2147483602 -2147483601 -2147483600 -2147483599 -2147483598 -2147483597 -2147483596 -2147483595 -2147483594 -2147483593 -2147483592 -2147483591 
		-2147483590 -2147483589 -2147483608;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit3";
	rename -uid "CDE876D7-491D-E074-7D9E-679176DCEA08";
	setAttr -s 21 ".e[0:20]"  0.51185 0.51185 0.51185 0.51185 0.51185 0.51185
		 0.51185 0.51185 0.51185 0.51185 0.51185 0.51185 0.51185 0.51185 0.51185 0.51185 0.51185
		 0.51185 0.51185 0.51185 0.51185;
	setAttr -s 21 ".d[0:20]"  -2147483608 -2147483607 -2147483606 -2147483605 -2147483604 -2147483603 
		-2147483602 -2147483601 -2147483600 -2147483599 -2147483598 -2147483597 -2147483596 -2147483595 -2147483594 -2147483593 -2147483592 -2147483591 
		-2147483590 -2147483589 -2147483608;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyTweak -n "polyTweak1";
	rename -uid "D1F18DFA-4742-FA1E-CFBA-25B352E4D498";
	setAttr ".uopa" yes;
	setAttr -s 20 ".tk[42:61]" -type "float3"  0.12188192 0 -0.039601799
		 0.10367893 0 -0.075327136 0.075327151 0 -0.10367892 0.039601814 0 -0.12188178 1.5277154e-08
		 0 -0.1281541 -0.039601799 0 -0.12188178 -0.075327128 0 -0.10367888 -0.10367888 0
		 -0.075327083 -0.12188178 0 -0.039601792 -0.12815408 0 2.291574e-08 -0.12188178 0
		 0.039601814 -0.10367887 0 0.075327143 -0.075327083 0 0.10367888 -0.039601799 0 0.12188178
		 1.145787e-08 0 0.1281541 0.039601807 0 0.12188178 0.075327128 0 0.10367888 0.10367888
		 0 0.075327136 0.12188178 0 0.03960181 0.12815408 0 2.291574e-08;
createNode polySplit -n "polySplit2";
	rename -uid "0A82CF29-4CE3-45EE-3506-E9A14C2C056D";
	setAttr -s 21 ".e[0:20]"  0.92689401 0.92689401 0.92689401 0.92689401
		 0.92689401 0.92689401 0.92689401 0.92689401 0.92689401 0.92689401 0.92689401 0.92689401
		 0.92689401 0.92689401 0.92689401 0.92689401 0.92689401 0.92689401 0.92689401 0.92689401
		 0.92689401;
	setAttr -s 21 ".d[0:20]"  -2147483608 -2147483607 -2147483606 -2147483605 -2147483604 -2147483603 
		-2147483602 -2147483601 -2147483600 -2147483599 -2147483598 -2147483597 -2147483596 -2147483595 -2147483594 -2147483593 -2147483592 -2147483591 
		-2147483590 -2147483589 -2147483608;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polySplit -n "polySplit1";
	rename -uid "2AE20636-4DB0-ABFC-4190-2AB1CA2518CF";
	setAttr -s 21 ".e[0:20]"  0.92971998 0.92971998 0.92971998 0.92971998
		 0.92971998 0.92971998 0.92971998 0.92971998 0.92971998 0.92971998 0.92971998 0.92971998
		 0.92971998 0.92971998 0.92971998 0.92971998 0.92971998 0.92971998 0.92971998 0.92971998
		 0.92971998;
	setAttr -s 21 ".d[0:20]"  -2147483608 -2147483607 -2147483606 -2147483605 -2147483604 -2147483603 
		-2147483602 -2147483601 -2147483600 -2147483599 -2147483598 -2147483597 -2147483596 -2147483595 -2147483594 -2147483593 -2147483592 -2147483591 
		-2147483590 -2147483589 -2147483608;
	setAttr ".sma" 180;
	setAttr ".m2015" yes;
createNode polyCylinder -n "polyCylinder1";
	rename -uid "89E54EDF-48AE-795B-D86B-CB85F694B79F";
	setAttr ".sc" 1;
	setAttr ".cuv" 3;
select -ne :time1;
	setAttr ".o" 1;
	setAttr ".unw" 1;
select -ne :hardwareRenderingGlobals;
	setAttr ".otfna" -type "stringArray" 22 "NURBS Curves" "NURBS Surfaces" "Polygons" "Subdiv Surface" "Particles" "Particle Instance" "Fluids" "Strokes" "Image Planes" "UI" "Lights" "Cameras" "Locators" "Joints" "IK Handles" "Deformers" "Motion Trails" "Components" "Hair Systems" "Follicles" "Misc. UI" "Ornaments"  ;
	setAttr ".otfva" -type "Int32Array" 22 0 1 1 1 1 1
		 1 1 1 0 0 0 0 0 0 0 0 0
		 0 0 0 0 ;
	setAttr ".fprt" yes;
select -ne :renderPartition;
	setAttr -s 2 ".st";
select -ne :renderGlobalsList1;
select -ne :defaultShaderList1;
	setAttr -s 4 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderingList1;
select -ne :initialShadingGroup;
	setAttr -s 2 ".dsm";
	setAttr ".ro" yes;
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultResolution;
	setAttr ".pa" 1;
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
connectAttr "polySplit6.out" "pCylinderShape1.i";
connectAttr "polySplit8.out" "pCubeShape1.i";
connectAttr "polyTweak2.out" "polySplit8.ip";
connectAttr "polySplit7.out" "polyTweak2.ip";
connectAttr "polyCube1.out" "polySplit7.ip";
connectAttr "polySplit5.out" "polySplit6.ip";
connectAttr "polySplit4.out" "polySplit5.ip";
connectAttr "polySplit3.out" "polySplit4.ip";
connectAttr "polyTweak1.out" "polySplit3.ip";
connectAttr "polySplit2.out" "polyTweak1.ip";
connectAttr "polySplit1.out" "polySplit2.ip";
connectAttr "polyCylinder1.out" "polySplit1.ip";
connectAttr "pCylinderShape1.iog" ":initialShadingGroup.dsm" -na;
connectAttr "pCubeShape1.iog" ":initialShadingGroup.dsm" -na;
// End of NewBazuka.ma
