# ACESinspector
C# Windows Forms app for validating automotive catalog ACES xml file content

# Changelog

1.0.1.17 (released 5/18/2017)
Added IComparable method to VCdbAttributes class for sorting attributes within an app to conform to the XSD-mandated sequence. This fixed the exported net-changes ACES xml file to pass xsd validation.

1.0.1.16 ((released 5/16/2017)
Introduced 2-file differential calculation
Added Adds/Drops Parts & Adds/Drops Vehicles tabs
Added export of net-changes 
Introduced registry-resident validation history storage
Included invalid parttypes and positions in Parttypes-Positions tab

1.0.1.15 (released 5/10/2017)
Defaulted position to 0 on import and excluded 0 and 1 (N/A) from parttype/position audit
Changed “mfrid” to “enginemfrid” in the attributeWhereClause() function
Changed “mfrid” to “transmissionmfrid” in the attributeWhereClause() function

