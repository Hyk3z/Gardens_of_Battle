//Maya ASCII 2018 scene
//Name: Rockss.ma
//Last modified: Tue, Feb 16, 2021 03:40:24 PM
//Codeset: 1252
requires maya "2018";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2018";
fileInfo "version" "2018";
fileInfo "cutIdentifier" "201706261615-f9658c4cfc";
fileInfo "osv" "Microsoft Windows 8 Home Premium Edition, 64-bit  (Build 9200)\n";
fileInfo "license" "student";
createNode transform -n "pSphere3";
	rename -uid "D593FB14-401D-F280-44A4-418C70314044";
	setAttr ".t" -type "double3" 0 0.28777505378562385 0 ;
	setAttr ".s" -type "double3" 1 0.50711587123958513 1 ;
createNode mesh -n "pSphereShape3" -p "pSphere3";
	rename -uid "443E29B5-4DCF-0761-6C8C-35B11111DA77";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.66666668653488159 0.83333337306976318 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 32 ".pt[0:31]" -type "float3"  0 0.079619162 0 0 0.079619162 
		-2.1054607e-08 0 0.079619162 0 0.10905677 0.079619162 -0.1696385 3.5768877e-09 0.079619162 
		-1.0967108e-08 0 0.079619162 0 0 -0.1715555 0.10581811 0 -0.1715555 0.10581814 0.23548916 
		-0.1715555 -0.13755333 0.15821382 -0.1715555 -0.35134545 -0.077970058 0.087140299 
		-0.24201025 -0.078063264 -0.1715555 0.044750173 -0.16642004 0.069472224 0.29910308 
		0.1251312 1.2509532e-15 0.3200382 0.42264429 8.7566732e-15 -0.1375533 0.23695524 
		0 -0.50932789 -0.16948119 -0.0102606 -0.34854072 -0.27496359 0 0.034397632 -0.055287898 
		0.27255368 0.25794834 0.109644 0.38883898 0.268709 0.36521736 0.0087987576 -0.13755333 
		0.18246453 0.0054722247 -0.4803178 -0.16028346 -0.13837957 -0.34157577 -0.24050744 
		0.12031621 0.020288683 0 0.57317859 0 0 0.33821008 -2.1054607e-08 0.1298978 -0.055838954 
		0 0.10905677 -0.055838954 -0.1696385 3.5768877e-09 0.060440544 -0.21120377 0 0.33821008 
		0 0 0.1715555 0 0 0.27373281 0;
createNode transform -n "pSphere4";
	rename -uid "9C06FA7F-46CB-36D9-E3C8-90AA6492215E";
	setAttr ".t" -type "double3" 0 0.34234419134995997 2.5072211731723493 ;
	setAttr ".s" -type "double3" 0.59669721434928957 0.59669721434928957 0.59669721434928957 ;
createNode mesh -n "pSphereShape4" -p "pSphere4";
	rename -uid "B970A441-4B2C-9586-1962-E0A5070FFF49";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.5 0.5 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 21 ".pt";
	setAttr ".pt[6]" -type "float3" -0.10566646 -0.08823029 0.18544063 ;
	setAttr ".pt[7]" -type "float3" -0.0063127512 -7.2164497e-16 0.17292033 ;
	setAttr ".pt[8]" -type "float3" 0.1181716 0 0 ;
	setAttr ".pt[10]" -type "float3" 0.018728584 0 -0.2322333 ;
	setAttr ".pt[11]" -type "float3" -0.26250681 0 0.23627442 ;
	setAttr ".pt[12]" -type "float3" -0.093777202 0 0.283342 ;
	setAttr ".pt[13]" -type "float3" 0.15714039 1.488491e-15 0.32935697 ;
	setAttr ".pt[14]" -type "float3" 0.282455 0 0 ;
	setAttr ".pt[15]" -type "float3" 0.27952379 0 -0.19352102 ;
	setAttr ".pt[16]" -type "float3" -0.18163669 7.442455e-16 -0.16247378 ;
	setAttr ".pt[17]" -type "float3" -0.35997501 0 0 ;
	setAttr ".pt[18]" -type "float3" -0.039849527 0.08823029 0.21359329 ;
	setAttr ".pt[19]" -type "float3" 0.11650661 0 0.20566753 ;
	setAttr ".pt[20]" -type "float3" 0.27961138 0 0 ;
	setAttr ".pt[21]" -type "float3" 0.11932867 0 -0.25872931 ;
	setAttr ".pt[22]" -type "float3" -0.17405088 6.1062266e-16 -0.18534146 ;
	setAttr ".pt[23]" -type "float3" -0.30160925 0 0.20961303 ;
	setAttr ".pt[27]" -type "float3" -0.025027797 -1.110223e-16 -0.19270349 ;
	setAttr ".pt[28]" -type "float3" -0.23159941 0 -0.33219111 ;
	setAttr ".pt[29]" -type "float3" -0.2190337 0 0 ;
	setAttr ".pt[31]" -type "float3" 0 0.088514775 -0.31279284 ;
createNode polySphere -n "polySphere4";
	rename -uid "F87744EE-4852-58C2-56C6-439643B13AF0";
	setAttr ".sa" 6;
	setAttr ".sh" 6;
createNode polySphere -n "polySphere3";
	rename -uid "9540BE0A-417D-17CA-B020-0C8FFECF2E0E";
	setAttr ".sa" 6;
	setAttr ".sh" 6;
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
	setAttr -s 6 ".dsm";
	setAttr ".ro" yes;
	setAttr -s 4 ".gn";
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultResolution;
	setAttr ".pa" 1;
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
connectAttr "polySphere3.out" "pSphereShape3.i";
connectAttr "polySphere4.out" "pSphereShape4.i";
connectAttr "pSphereShape3.iog" ":initialShadingGroup.dsm" -na;
connectAttr "pSphereShape4.iog" ":initialShadingGroup.dsm" -na;
// End of Rockss.ma
