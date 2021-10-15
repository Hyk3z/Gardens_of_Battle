//Maya ASCII 2018 scene
//Name: newwood.ma
//Last modified: Fri, Feb 12, 2021 03:40:52 PM
//Codeset: 1252
requires maya "2018";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2018";
fileInfo "version" "2018";
fileInfo "cutIdentifier" "201706261615-f9658c4cfc";
fileInfo "osv" "Microsoft Windows 8 Home Premium Edition, 64-bit  (Build 9200)\n";
fileInfo "license" "student";
createNode transform -n "pCube1";
	rename -uid "CA3326B6-4854-0D5D-3EE3-6E9EE27F4BFB";
createNode mesh -n "pCubeShape1" -p "pCube1";
	rename -uid "17A2F67A-4462-9515-0E65-FBA9008E7EFB";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.375 0.49999982118606567 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 329 ".pt";
	setAttr ".pt[0]" -type "float3" -0.0087314751 0 0.0087314751 ;
	setAttr ".pt[7]" -type "float3" 0.045668725 0 -0.13229209 ;
	setAttr ".pt[8]" -type "float3" 0.015222904 0 -0.13229209 ;
	setAttr ".pt[9]" -type "float3" -0.015222904 0 -0.13229209 ;
	setAttr ".pt[11]" -type "float3" -0.034925897 0 -0.030560158 ;
	setAttr ".pt[12]" -type "float3" -0.0087314751 0 0.0087314751 ;
	setAttr ".pt[19]" -type "float3" 0.045668725 0 -0.13229209 ;
	setAttr ".pt[20]" -type "float3" 0.015222904 0 -0.13229209 ;
	setAttr ".pt[21]" -type "float3" -0.015222904 0 -0.13229209 ;
	setAttr ".pt[23]" -type "float3" -0.034925897 0 -0.030560158 ;
	setAttr ".pt[24]" -type "float3" -0.0087314751 0 0.0087314751 ;
	setAttr ".pt[31]" -type "float3" 0.045668725 0 -0.13229209 ;
	setAttr ".pt[32]" -type "float3" 0.015222904 0 -0.13229209 ;
	setAttr ".pt[33]" -type "float3" -0.015222904 0 -0.13229209 ;
	setAttr ".pt[35]" -type "float3" -0.034925897 0 -0.030560158 ;
	setAttr ".pt[36]" -type "float3" -0.0087314751 0 0.0087314751 ;
	setAttr ".pt[43]" -type "float3" 0.045668725 0 -0.13229209 ;
	setAttr ".pt[44]" -type "float3" 0.015222904 0 -0.13229209 ;
	setAttr ".pt[45]" -type "float3" -0.015222904 0 -0.13229209 ;
	setAttr ".pt[47]" -type "float3" -0.034925897 0 -0.030560158 ;
	setAttr ".pt[48]" -type "float3" -0.0087314751 0 0.0087314751 ;
	setAttr ".pt[49]" -type "float3" 0.060012318 0 0 ;
	setAttr ".pt[50]" -type "float3" 0.06346409 0 -0.25709432 ;
	setAttr ".pt[51]" -type "float3" 0.06346409 0 -0.25709432 ;
	setAttr ".pt[52]" -type "float3" 0.06346409 0 0 ;
	setAttr ".pt[59]" -type "float3" -0.034925897 0 -0.030560158 ;
	setAttr ".pt[60]" -type "float3" -0.0087314751 0 0.0087314751 ;
	setAttr ".pt[61]" -type "float3" 0.060012318 0 0 ;
	setAttr ".pt[62]" -type "float3" 0.06346409 0 -0.25709432 ;
	setAttr ".pt[63]" -type "float3" 0.06346409 0 -0.25709432 ;
	setAttr ".pt[64]" -type "float3" 0.06346409 0 0 ;
	setAttr ".pt[71]" -type "float3" -0.034925897 0 -0.030560158 ;
	setAttr ".pt[72]" -type "float3" -0.0087314751 0 0.0087314751 ;
	setAttr ".pt[73]" -type "float3" 0.060012318 0 0 ;
	setAttr ".pt[74]" -type "float3" 0.06346409 0 -0.25709432 ;
	setAttr ".pt[75]" -type "float3" 0.06346409 0 -0.25709432 ;
	setAttr ".pt[76]" -type "float3" 0.06346409 0 0 ;
	setAttr ".pt[79]" -type "float3" 0 0 -0.081721582 ;
	setAttr ".pt[83]" -type "float3" -0.034925897 0 -0.030560158 ;
	setAttr ".pt[84]" -type "float3" -0.0087314751 0 0.0087314751 ;
	setAttr ".pt[85]" -type "float3" 0.060012318 0 0 ;
	setAttr ".pt[86]" -type "float3" 0.06346409 0 -0.25709432 ;
	setAttr ".pt[87]" -type "float3" 0.06346409 0 -0.25709432 ;
	setAttr ".pt[91]" -type "float3" 0 0 -0.081721582 ;
	setAttr ".pt[95]" -type "float3" -0.034925897 0 -0.030560158 ;
	setAttr ".pt[96]" -type "float3" -0.0087314751 0 0.0087314751 ;
	setAttr ".pt[97]" -type "float3" 0.060012318 0 0 ;
	setAttr ".pt[98]" -type "float3" 0.06346409 0 -0.25709432 ;
	setAttr ".pt[99]" -type "float3" 0.06346409 0 -0.25709432 ;
	setAttr ".pt[103]" -type "float3" 0 0 -0.081721582 ;
	setAttr ".pt[104]" -type "float3" 0 0 -0.081721582 ;
	setAttr ".pt[107]" -type "float3" -0.034925897 0 -0.030560158 ;
	setAttr ".pt[108]" -type "float3" -0.0087314751 0 0.0087314751 ;
	setAttr ".pt[109]" -type "float3" 0.060012318 0 0 ;
	setAttr ".pt[110]" -type "float3" 0.06346409 0 -0.25709432 ;
	setAttr ".pt[111]" -type "float3" 0.06346409 0 -0.25709432 ;
	setAttr ".pt[115]" -type "float3" 0 0 -0.081721582 ;
	setAttr ".pt[116]" -type "float3" 0 0 -0.081721582 ;
	setAttr ".pt[119]" -type "float3" -0.034925897 0 -0.030560158 ;
	setAttr ".pt[120]" -type "float3" -0.0087314751 0 0.0087314751 ;
	setAttr ".pt[121]" -type "float3" 0.060012318 0 0 ;
	setAttr ".pt[122]" -type "float3" 0.06346409 0 -0.25709432 ;
	setAttr ".pt[123]" -type "float3" 0.06346409 0 -0.25709432 ;
	setAttr ".pt[128]" -type "float3" 0 0 -0.081721582 ;
	setAttr ".pt[131]" -type "float3" -0.034925897 0 -0.030560158 ;
	setAttr ".pt[132]" -type "float3" -0.0087314751 0 0.0087314751 ;
	setAttr ".pt[134]" -type "float3" 0.06346409 0 -0.25709432 ;
	setAttr ".pt[135]" -type "float3" 0.06346409 0 -0.25709432 ;
	setAttr ".pt[140]" -type "float3" 0 0 -0.081721589 ;
	setAttr ".pt[143]" -type "float3" -0.034925897 0 -0.030560158 ;
	setAttr ".pt[146]" -type "float3" 0.06346409 0 -0.2167635 ;
	setAttr ".pt[147]" -type "float3" 0.06346409 0 -0.2167635 ;
	setAttr ".pt[152]" -type "float3" 0 0 -0.081721589 ;
	setAttr ".pt[158]" -type "float3" 0.06346409 0 -0.1764324 ;
	setAttr ".pt[159]" -type "float3" 0.06346409 0 -0.1764324 ;
	setAttr ".pt[170]" -type "float3" 0.06346409 0 -0.13610163 ;
	setAttr ".pt[171]" -type "float3" 0.06346409 0 -0.13610163 ;
	setAttr ".pt[182]" -type "float3" 0.10073999 -0.046210773 -0.095770627 ;
	setAttr ".pt[183]" -type "float3" 0.08743611 -0.046210773 -0.095770627 ;
	setAttr ".pt[192]" -type "float3" 0.073170908 -0.046210773 0 ;
	setAttr ".pt[193]" -type "float3" 0.059867114 -0.046210773 0 ;
	setAttr ".pt[194]" -type "float3" 0.10073999 -0.046210773 -0.055439662 ;
	setAttr ".pt[195]" -type "float3" 0.08743611 -0.046210773 -0.055439662 ;
	setAttr ".pt[196]" -type "float3" 0.019955702 -0.046210773 0 ;
	setAttr ".pt[197]" -type "float3" 0.0066518988 -0.046210773 0 ;
	setAttr ".pt[198]" -type "float3" -0.006651904 -0.046210773 0 ;
	setAttr ".pt[199]" -type "float3" -0.019955706 -0.046210773 0 ;
	setAttr ".pt[200]" -type "float3" -0.033259507 -0.046210773 0 ;
	setAttr ".pt[201]" -type "float3" -0.046563305 -0.046210773 0 ;
	setAttr ".pt[202]" -type "float3" -0.059867118 -0.046210773 0 ;
	setAttr ".pt[203]" -type "float3" -0.073170908 -0.046210773 0 ;
	setAttr ".pt[204]" -type "float3" 0.073170908 -0.046210773 0 ;
	setAttr ".pt[205]" -type "float3" 0.059867114 -0.046210773 0 ;
	setAttr ".pt[206]" -type "float3" 0.046563305 -0.046210773 0 ;
	setAttr ".pt[207]" -type "float3" 0.033259504 -0.046210773 0 ;
	setAttr ".pt[208]" -type "float3" 0.019955702 -0.046210773 0 ;
	setAttr ".pt[209]" -type "float3" 0.0066518988 -0.046210773 0 ;
	setAttr ".pt[210]" -type "float3" -0.006651904 -0.046210773 0 ;
	setAttr ".pt[211]" -type "float3" -0.019955706 -0.046210773 0 ;
	setAttr ".pt[212]" -type "float3" -0.033259507 -0.046210773 0 ;
	setAttr ".pt[213]" -type "float3" -0.046563305 -0.046210773 0 ;
	setAttr ".pt[214]" -type "float3" -0.059867118 -0.046210773 0 ;
	setAttr ".pt[215]" -type "float3" -0.073170908 -0.046210773 0 ;
	setAttr ".pt[216]" -type "float3" 0.073170908 -0.046210773 0 ;
	setAttr ".pt[217]" -type "float3" 0.059867114 -0.046210773 0 ;
	setAttr ".pt[218]" -type "float3" 0.046563305 -0.046210773 0 ;
	setAttr ".pt[219]" -type "float3" 0.033259504 -0.046210773 0 ;
	setAttr ".pt[220]" -type "float3" 0.019955702 -0.046210773 0 ;
	setAttr ".pt[221]" -type "float3" 0.0066518988 -0.046210773 0 ;
	setAttr ".pt[222]" -type "float3" -0.006651904 -0.046210773 0 ;
	setAttr ".pt[223]" -type "float3" -0.019955706 -0.046210773 0 ;
	setAttr ".pt[224]" -type "float3" -0.033259507 -0.046210773 0 ;
	setAttr ".pt[225]" -type "float3" -0.046563305 -0.046210773 0 ;
	setAttr ".pt[226]" -type "float3" -0.059867118 -0.046210773 0 ;
	setAttr ".pt[227]" -type "float3" -0.073170908 -0.046210773 0 ;
	setAttr ".pt[228]" -type "float3" 0.073170908 -0.046210773 0 ;
	setAttr ".pt[229]" -type "float3" 0.059867114 -0.046210773 0 ;
	setAttr ".pt[230]" -type "float3" 0.046563305 -0.046210773 0 ;
	setAttr ".pt[231]" -type "float3" 0.033259504 -0.046210773 0 ;
	setAttr ".pt[232]" -type "float3" 0.019955702 -0.046210773 0 ;
	setAttr ".pt[233]" -type "float3" 0.0066518988 -0.046210773 0 ;
	setAttr ".pt[234]" -type "float3" -0.006651904 -0.046210773 0 ;
	setAttr ".pt[235]" -type "float3" -0.019955706 -0.046210773 0 ;
	setAttr ".pt[236]" -type "float3" -0.033259507 -0.046210773 0 ;
	setAttr ".pt[240]" -type "float3" 0.073170908 -0.046210773 0 ;
	setAttr ".pt[264]" -type "float3" 0.013097212 0 0.026194422 ;
	setAttr ".pt[275]" -type "float3" -0.034925897 0 0.030560158 ;
	setAttr ".pt[276]" -type "float3" 0.013097212 0 0.026194422 ;
	setAttr ".pt[287]" -type "float3" -0.034925897 0 0.030560158 ;
	setAttr ".pt[288]" -type "float3" 0.013097212 0 0.026194422 ;
	setAttr ".pt[299]" -type "float3" -0.034925897 0 0.030560158 ;
	setAttr ".pt[300]" -type "float3" 0.013097212 0 0.026194422 ;
	setAttr ".pt[311]" -type "float3" -0.034925897 0 0.030560158 ;
	setAttr ".pt[312]" -type "float3" 0.060012318 0 0 ;
	setAttr ".pt[314]" -type "float3" 0.06346409 0 0.18654603 ;
	setAttr ".pt[323]" -type "float3" -0.034925897 0 0.030560158 ;
	setAttr ".pt[324]" -type "float3" 0.060012318 0 0 ;
	setAttr ".pt[326]" -type "float3" 0.06346409 0 0.18654603 ;
	setAttr ".pt[335]" -type "float3" -0.034925897 0 0.030560158 ;
	setAttr ".pt[336]" -type "float3" 0.060012318 0 0 ;
	setAttr ".pt[337]" -type "float3" 0 0 7.4505806e-09 ;
	setAttr ".pt[338]" -type "float3" 0 0 7.4505806e-09 ;
	setAttr ".pt[339]" -type "float3" 0.06346409 0 0.18654603 ;
	setAttr ".pt[347]" -type "float3" -0.034925897 0 0.030560158 ;
	setAttr ".pt[348]" -type "float3" 0.060012318 0 0 ;
	setAttr ".pt[349]" -type "float3" 0.06346409 0 0.18654603 ;
	setAttr ".pt[350]" -type "float3" 0.06346409 0 0.18654603 ;
	setAttr ".pt[351]" -type "float3" 0.06346409 0 0.18654603 ;
	setAttr ".pt[359]" -type "float3" -0.034925897 0 0.030560158 ;
	setAttr ".pt[360]" -type "float3" 0.060012318 0 0 ;
	setAttr ".pt[361]" -type "float3" 0.06346409 0 0.18654603 ;
	setAttr ".pt[362]" -type "float3" 0.06346409 0 0.18654603 ;
	setAttr ".pt[363]" -type "float3" 0.06346409 0 0.18654603 ;
	setAttr ".pt[367]" -type "float3" 0.045668725 0 0.13229209 ;
	setAttr ".pt[368]" -type "float3" 0.015222904 0 0.13229209 ;
	setAttr ".pt[369]" -type "float3" -0.015222904 0 0.13229209 ;
	setAttr ".pt[370]" -type "float3" -0.045668725 0 0.13229209 ;
	setAttr ".pt[371]" -type "float3" -0.034925897 0 0.030560158 ;
	setAttr ".pt[372]" -type "float3" 0.060012318 0 0 ;
	setAttr ".pt[373]" -type "float3" 0.06346409 0 0.18654603 ;
	setAttr ".pt[374]" -type "float3" 0.06346409 0 0.18654603 ;
	setAttr ".pt[375]" -type "float3" 0.06346409 0 0.18654603 ;
	setAttr ".pt[379]" -type "float3" 0.045668725 0 0.13229209 ;
	setAttr ".pt[380]" -type "float3" 0.015222904 0 0.13229209 ;
	setAttr ".pt[381]" -type "float3" -0.015222904 0 0.13229209 ;
	setAttr ".pt[382]" -type "float3" -0.045668725 0 0.13229209 ;
	setAttr ".pt[383]" -type "float3" -0.034925897 0 0.030560158 ;
	setAttr ".pt[384]" -type "float3" 0.060012318 0 0 ;
	setAttr ".pt[385]" -type "float3" 0.06346409 0 0.18654603 ;
	setAttr ".pt[386]" -type "float3" 0.06346409 0 0.18654603 ;
	setAttr ".pt[387]" -type "float3" 0.06346409 0 0.18654603 ;
	setAttr ".pt[388]" -type "float3" 0.06346409 0 0 ;
	setAttr ".pt[391]" -type "float3" 0.045668725 0 0.13229209 ;
	setAttr ".pt[392]" -type "float3" 0.015222904 0 0.13229209 ;
	setAttr ".pt[393]" -type "float3" -0.015222904 0 0.13229209 ;
	setAttr ".pt[395]" -type "float3" -0.034925897 0 0.030560158 ;
	setAttr ".pt[396]" -type "float3" 0.060012318 0 0 ;
	setAttr ".pt[397]" -type "float3" 0.06346409 0 0.18654603 ;
	setAttr ".pt[398]" -type "float3" 0.06346409 0 0.18654603 ;
	setAttr ".pt[399]" -type "float3" 0.06346409 0 0.18654603 ;
	setAttr ".pt[400]" -type "float3" 0.06346409 0 0 ;
	setAttr ".pt[403]" -type "float3" 0.045668725 0 0.13229209 ;
	setAttr ".pt[404]" -type "float3" 0.015222904 0 0.13229209 ;
	setAttr ".pt[405]" -type "float3" -0.015222904 0 0.13229209 ;
	setAttr ".pt[407]" -type "float3" -0.034925897 0 0.030560158 ;
	setAttr ".pt[408]" -type "float3" 0.060012318 0 0 ;
	setAttr ".pt[409]" -type "float3" 0.11269252 0 0.14621511 ;
	setAttr ".pt[410]" -type "float3" 0.099744126 0 0.14621511 ;
	setAttr ".pt[411]" -type "float3" 0.086795732 0 0.14621511 ;
	setAttr ".pt[412]" -type "float3" 0.06346409 0 0 ;
	setAttr ".pt[415]" -type "float3" 0.045668725 0 0.10823895 ;
	setAttr ".pt[416]" -type "float3" 0.015222904 0 0.10823895 ;
	setAttr ".pt[417]" -type "float3" -0.015222904 0 0.10823895 ;
	setAttr ".pt[420]" -type "float3" 0.12268075 0 0 ;
	setAttr ".pt[421]" -type "float3" 0.11269252 0 0.10588414 ;
	setAttr ".pt[422]" -type "float3" 0.099744126 0 0.10588414 ;
	setAttr ".pt[423]" -type "float3" 0.086795732 0 0.10588414 ;
	setAttr ".pt[424]" -type "float3" 0.06346409 0 0 ;
	setAttr ".pt[427]" -type "float3" 0.045668725 0 0.084185883 ;
	setAttr ".pt[428]" -type "float3" 0.015222904 0 0.084185883 ;
	setAttr ".pt[429]" -type "float3" -0.015222904 0 0.084185883 ;
	setAttr ".pt[432]" -type "float3" 0.071216166 0 0 ;
	setAttr ".pt[433]" -type "float3" 0.11269252 0 0.065553188 ;
	setAttr ".pt[434]" -type "float3" 0.099744126 0 0.065553188 ;
	setAttr ".pt[435]" -type "float3" 0.086795732 0 0.065553188 ;
	setAttr ".pt[436]" -type "float3" 0.06346409 0 0 ;
	setAttr ".pt[439]" -type "float3" 0.045668725 0 0.060132772 ;
	setAttr ".pt[440]" -type "float3" 0.015222904 0 0.060132772 ;
	setAttr ".pt[441]" -type "float3" -0.015222904 0 0.060132772 ;
	setAttr ".pt[444]" -type "float3" 0.071216166 0 0 ;
	setAttr ".pt[445]" -type "float3" 0.11269252 0 0.025222231 ;
	setAttr ".pt[446]" -type "float3" 0.099744126 0 0.025222231 ;
	setAttr ".pt[447]" -type "float3" 0.086795732 0 0.025222231 ;
	setAttr ".pt[448]" -type "float3" 0.019422589 0 0 ;
	setAttr ".pt[451]" -type "float3" 0.045668725 0 0.036079656 ;
	setAttr ".pt[452]" -type "float3" 0.015222904 0 0.036079656 ;
	setAttr ".pt[453]" -type "float3" -0.015222904 0 0.036079656 ;
	setAttr ".pt[456]" -type "float3" 0.071216166 0 0 ;
	setAttr ".pt[457]" -type "float3" 0.11269252 0 -0.015108705 ;
	setAttr ".pt[458]" -type "float3" 0.099744126 0 -0.015108705 ;
	setAttr ".pt[459]" -type "float3" 0.086795732 0 -0.015108705 ;
	setAttr ".pt[460]" -type "float3" 0.019422589 0 0 ;
	setAttr ".pt[463]" -type "float3" 0.045668725 0 0.012026548 ;
	setAttr ".pt[464]" -type "float3" 0.015222904 0 0.012026548 ;
	setAttr ".pt[465]" -type "float3" -0.015222904 0 0.012026548 ;
	setAttr ".pt[469]" -type "float3" 0.11269252 0 -0.055439692 ;
	setAttr ".pt[470]" -type "float3" 0.099744126 0 -0.055439692 ;
	setAttr ".pt[471]" -type "float3" 0.086795732 0 -0.055439692 ;
	setAttr ".pt[475]" -type "float3" 0.045668725 0 -0.012026555 ;
	setAttr ".pt[476]" -type "float3" 0.015222904 0 -0.012026555 ;
	setAttr ".pt[477]" -type "float3" -0.015222904 0 -0.012026555 ;
	setAttr ".pt[481]" -type "float3" 0.06346409 0 -0.095770657 ;
	setAttr ".pt[482]" -type "float3" 0.06346409 0 -0.095770657 ;
	setAttr ".pt[483]" -type "float3" 0.06346409 0 -0.095770657 ;
	setAttr ".pt[487]" -type "float3" 0.045668725 0 -0.03607966 ;
	setAttr ".pt[488]" -type "float3" 0.015222904 0 -0.03607966 ;
	setAttr ".pt[489]" -type "float3" -0.015222904 0 -0.03607966 ;
	setAttr ".pt[499]" -type "float3" 0.045668725 0 -0.060132787 ;
	setAttr ".pt[500]" -type "float3" 0.015222904 0 -0.060132787 ;
	setAttr ".pt[501]" -type "float3" -0.015222904 0 -0.060132787 ;
	setAttr ".pt[511]" -type "float3" 0.045668725 0 -0.084185883 ;
	setAttr ".pt[512]" -type "float3" 0.015222904 0 -0.084185883 ;
	setAttr ".pt[513]" -type "float3" -0.015222904 0 -0.084185883 ;
	setAttr ".pt[523]" -type "float3" 0.045668725 0 -0.10823897 ;
	setAttr ".pt[524]" -type "float3" 0.015222904 0 -0.10823897 ;
	setAttr ".pt[525]" -type "float3" -0.015222904 0 -0.10823897 ;
	setAttr ".pt[551]" -type "float3" -0.071216166 0 0 ;
	setAttr ".pt[552]" -type "float3" -0.071216166 0 0 ;
	setAttr ".pt[553]" -type "float3" -0.071216166 0 0 ;
	setAttr ".pt[561]" -type "float3" -0.071216166 0 0 ;
	setAttr ".pt[562]" -type "float3" -0.071216166 0 0 ;
	setAttr ".pt[563]" -type "float3" -0.071216166 0 0 ;
	setAttr ".pt[571]" -type "float3" -0.071216166 0 0 ;
	setAttr ".pt[572]" -type "float3" -0.071216166 0 0 ;
	setAttr ".pt[573]" -type "float3" -0.071216166 0 0 ;
	setAttr ".pt[581]" -type "float3" -0.13396515 0.03080719 0 ;
	setAttr ".pt[582]" -type "float3" -0.13396515 0.03080719 0 ;
	setAttr ".pt[583]" -type "float3" -0.13396515 0.03080719 0 ;
	setAttr ".pt[591]" -type "float3" -0.073170908 0.015403591 0 ;
	setAttr ".pt[592]" -type "float3" -0.073170908 0.015403591 0 ;
	setAttr ".pt[593]" -type "float3" -0.073170908 0.015403591 0 ;
	setAttr ".pt[601]" -type "float3" -0.073170908 -2.7504345e-09 0 ;
	setAttr ".pt[602]" -type "float3" -0.073170908 -2.7504345e-09 0 ;
	setAttr ".pt[603]" -type "float3" -0.073170908 -2.7504345e-09 0 ;
	setAttr ".pt[611]" -type "float3" -0.073170908 -0.015403598 0 ;
	setAttr ".pt[612]" -type "float3" -0.073170908 -0.015403598 0 ;
	setAttr ".pt[613]" -type "float3" -0.073170908 -0.015403598 0 ;
	setAttr ".pt[621]" -type "float3" -0.073170908 -0.030807193 0 ;
	setAttr ".pt[622]" -type "float3" -0.073170908 -0.030807193 0 ;
	setAttr ".pt[623]" -type "float3" -0.073170908 -0.030807193 0 ;
	setAttr ".pt[628]" -type "float3" 0.060012318 0 0 ;
	setAttr ".pt[629]" -type "float3" 0.12268075 0 0 ;
	setAttr ".pt[630]" -type "float3" 0.12268075 0 0 ;
	setAttr ".pt[631]" -type "float3" 0.12268075 0 0 ;
	setAttr ".pt[632]" -type "float3" 0.071216166 0 0 ;
	setAttr ".pt[638]" -type "float3" 0.060012318 0 0 ;
	setAttr ".pt[639]" -type "float3" 0.060012318 0 0 ;
	setAttr ".pt[640]" -type "float3" 0.12268075 0 0 ;
	setAttr ".pt[641]" -type "float3" 0.12268075 0 0 ;
	setAttr ".pt[642]" -type "float3" 0.12268075 0 0 ;
	setAttr ".pt[643]" -type "float3" 0.060012318 0 0 ;
	setAttr ".pt[644]" -type "float3" 0.060012318 0 0 ;
	setAttr ".pt[648]" -type "float3" 0.060012318 0 0 ;
	setAttr ".pt[649]" -type "float3" 0.060012318 0 0 ;
	setAttr ".pt[650]" -type "float3" 0.12268075 0 0 ;
	setAttr ".pt[651]" -type "float3" 0.12268075 0 0 ;
	setAttr ".pt[652]" -type "float3" 0.12268075 0 0 ;
	setAttr ".pt[653]" -type "float3" 0.060012318 0 0 ;
	setAttr ".pt[654]" -type "float3" 0.060012318 0 0 ;
	setAttr ".pt[658]" -type "float3" 0.060012318 0 0 ;
	setAttr ".pt[659]" -type "float3" 0.060012318 0 0 ;
	setAttr ".pt[660]" -type "float3" 0.060012318 0 0 ;
	setAttr ".pt[661]" -type "float3" 0.060012318 0 0 ;
	setAttr ".pt[662]" -type "float3" 0.060012318 0 0 ;
	setAttr ".pt[663]" -type "float3" 0.060012318 0 0 ;
	setAttr ".pt[668]" -type "float3" 0.060012318 0 0 ;
	setAttr ".pt[669]" -type "float3" 0.12440089 0.046210773 0 ;
	setAttr ".pt[670]" -type "float3" 0.12440089 0.046210773 0 ;
	setAttr ".pt[671]" -type "float3" 0.12440089 0.046210773 0 ;
	setAttr ".pt[672]" -type "float3" 0.12440089 0.046210773 0 ;
	setAttr ".pt[673]" -type "float3" 0.073170908 0.046210773 0 ;
	setAttr ".pt[678]" -type "float3" 0.060012318 0 0 ;
	setAttr ".pt[679]" -type "float3" 0.12440089 0.03080719 0 ;
	setAttr ".pt[680]" -type "float3" 0.12440089 0.03080719 0 ;
	setAttr ".pt[681]" -type "float3" 0.12440089 0.03080719 0 ;
	setAttr ".pt[682]" -type "float3" 0.12440089 0.03080719 0 ;
	setAttr ".pt[683]" -type "float3" 0.073170908 0.03080719 0 ;
	setAttr ".pt[688]" -type "float3" 0.060012318 0 0 ;
	setAttr ".pt[689]" -type "float3" 0.12440089 0.015403591 0 ;
	setAttr ".pt[690]" -type "float3" 0.12440089 0.015403591 0 ;
	setAttr ".pt[691]" -type "float3" 0.12440089 0.015403591 0 ;
	setAttr ".pt[692]" -type "float3" 0.073170908 0.015403591 0 ;
	setAttr ".pt[693]" -type "float3" 0.073170908 0.015403591 0 ;
	setAttr ".pt[698]" -type "float3" 0.060012318 0 0 ;
	setAttr ".pt[699]" -type "float3" 0.12440089 -2.7504345e-09 0 ;
	setAttr ".pt[700]" -type "float3" 0.12440089 -2.7504345e-09 0 ;
	setAttr ".pt[701]" -type "float3" 0.12440089 -2.7504345e-09 0 ;
	setAttr ".pt[702]" -type "float3" 0.073170908 -2.7504345e-09 0 ;
	setAttr ".pt[703]" -type "float3" 0.073170908 -2.7504345e-09 0 ;
	setAttr ".pt[709]" -type "float3" 0.073170908 -0.015403598 0 ;
	setAttr ".pt[710]" -type "float3" 0.073170908 -0.015403598 0 ;
	setAttr ".pt[711]" -type "float3" 0.073170908 -0.015403598 0 ;
	setAttr ".pt[712]" -type "float3" 0.073170908 -0.015403598 0 ;
	setAttr ".pt[713]" -type "float3" 0.073170908 -0.015403598 0 ;
	setAttr ".pt[719]" -type "float3" 0.073170908 -0.030807193 0 ;
	setAttr ".pt[720]" -type "float3" 0.073170908 -0.030807193 0 ;
	setAttr ".pt[721]" -type "float3" 0.073170908 -0.030807193 0 ;
	setAttr ".pt[722]" -type "float3" 0.073170908 -0.030807193 0 ;
	setAttr ".pt[723]" -type "float3" 0.073170908 -0.030807193 0 ;
createNode polyCube -n "polyCube1";
	rename -uid "984D9C4A-4DAE-44E1-977F-15BB0A95BA54";
	setAttr ".sw" 11;
	setAttr ".sh" 11;
	setAttr ".sd" 11;
	setAttr ".cuv" 4;
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
	setAttr ".ro" yes;
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultResolution;
	setAttr ".pa" 1;
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
connectAttr "polyCube1.out" "pCubeShape1.i";
connectAttr "pCubeShape1.iog" ":initialShadingGroup.dsm" -na;
// End of newwood.ma