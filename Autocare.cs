using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.OleDb;
using System.Xml.Linq;
using System.Xml;
using System.Xml.Schema;
using System.IO;
using System.Globalization;
using Microsoft.Win32;


namespace ACESinspector
{

    public class App : IComparable<App>
    {
        public int id;
        public char action;
        public int basevehilceid;
        public int parttypeid;
        public int positionid;
        public int quantity;
        public string part;
        public string notes;
        public string mfrlabel;
        public string asset;
        public int assetitemorder;
        public List<VCdbAttribute> VCdbAttributes;
        public App()
        {
            VCdbAttributes = new List<VCdbAttribute>();
            VCdbAttributes.Clear();
        }

        public string niceAttributesString(VCdb vcdb, bool includeNotes)
        {// returns human-readable (Limited; V6 2.3L;) rendition of VCdb-coded attributes in this app
            string returnString = "";
            foreach (VCdbAttribute myAttribute in VCdbAttributes) { returnString += " " + vcdb.niceAttribute(myAttribute)+";";}
            if (includeNotes) { returnString += " " + notes; }
            returnString=returnString.Trim();
            if (returnString != "" && returnString.Substring(returnString.Length - 1,1) == ";") { returnString = returnString.Substring(0, returnString.Length - 1); }
            return returnString;
        }

        public string namevalpairString(bool includeNotes)
        {// returns CSS-style (Submodel:13;EnvineBase:332;) rendition of VCdb-coded attributes in this app
            string returnString = "";
            foreach (VCdbAttribute myAttribute in VCdbAttributes) { returnString += myAttribute.name + ":" + myAttribute.value.ToString() + ";"; }
            if (includeNotes) { returnString += notes; }
            returnString.Trim();
            if (returnString !="" && returnString.Substring(returnString.Length - 1, 1) == ";") { returnString = returnString.Substring(0, returnString.Length - 1); }
            return returnString;
        }


        public int CompareTo(App other)
        {// this is the secret sauce. detecting overlaps, CNC's and duplicates is done by ordering all apps in such a ways as to do a row-to-row comparison of apps.
            // this function is use by Array.Sort() after all apps have been imported from the XML into memory
            int strCmpResults = 0;

            if (this.basevehilceid > other.basevehilceid)
            {//A basevehilceid > B basevehilceid
                return (+1);
            }
            else
            {//A basevehilceid <= B basevehilceid
                if (this.basevehilceid == other.basevehilceid)
                {//A basevehilceid = B basevehilceid -  now compare secondary stuff
                    if (this.parttypeid > other.parttypeid)
                    {// A parttypeid > B parttypeid
                        return (+1);
                    }
                    else
                    {// A parttypeid <= B parttypeid
                        if (this.parttypeid == other.parttypeid)
                        {// basebids are equal, parttypeids are equal

                            if (this.positionid > other.positionid)
                            {//A pos > B pos
                                return (+1);
                            }
                            else
                            {//A pos <= B pos
                                if (this.positionid == other.positionid)
                                {// basebids are equal, parttypeids are equal, positionids are equal
                                    if (string.Compare(this.part, other.part) > 0)
                                    {// a.part > b.part
                                        return (+1);
                                    }
                                    else
                                    {//a.part <= b.part
                                        if (this.part == other.part)
                                        {/// basebids are equal, parttypeids are equal, positionids are equal, parts are equal
                                            if (string.Compare(this.mfrlabel, other.mfrlabel) > 0)
                                            {// mfrlabels A > B
                                                return (+1);
                                            }
                                            else
                                            {// mfrlabels A <= B
                                                if (this.mfrlabel == other.mfrlabel)
                                                {
                                                    strCmpResults = string.Compare(this.namevalpairString(true), other.namevalpairString(true));
                                                    if (strCmpResults > 0)
                                                    {// qualifiers A > qualifiers B
                                                        return (+1);
                                                    }
                                                    else
                                                    {//qualifiers A <= qualifiers B
                                                        if (strCmpResults == 0)
                                                        {// basebids are equal, parttypeids are equal, positionids are equal, parts are equal, mfrlabels are equal, qualifiers are equal,
                                                            if (string.Compare(this.asset, other.asset) > 0)
                                                            {//assetid A > assetid B
                                                                return (+1);
                                                            }
                                                            else
                                                            {
                                                                if (this.asset == other.asset)
                                                                {// basebids are equal, parttypeids are equal, positionids are equal, parts are equal, mfrlabels are equal, qualifiers are equal, assetid's are equal
                                                                    if (this.assetitemorder > other.assetitemorder)
                                                                    {//assetorder A > assetorder B
                                                                        return (+1);
                                                                    }
                                                                    else
                                                                    {
                                                                        if (this.assetitemorder == other.assetitemorder)
                                                                        {// basebids are equal, parttypeids are equal, positionids are equal, parts are equal, mfrlabels are equal, qualifiers are equal, assetid's are equal, asset orders are equal
                                                                            return (0);
                                                                        }
                                                                        else
                                                                        {//assetorder A < assetorder B
                                                                            return (-1);
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {//assetid A < assetid B
                                                                    return (-1);
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {//qualifiers A < qualifiers B
                                                            return (-1);
                                                        }
                                                    }
                                                }
                                                else
                                                {// mfrlabel A < mfrlabel B
                                                    return (-1);
                                                }
                                            }
                                        }
                                        else
                                        {// A part < B part
                                            return (-1);
                                        }
                                    }
                                }
                                else
                                {//A pos < B pos
                                    return (-1);
                                }
                            }
                        }
                        else
                        {//  A parttypeid < B parttypeid
                            return (-1);
                        }
                    }
                }
                else
                {//A basevehilceid < B basevehilceid
                    return (-1);
                }
            }

        }

    }


    public class buyersguideApplication : IComparable<buyersguideApplication>
    {
        public string part;
        public string MakeName;
        public string ModelName;
        public int startYear;
        public int endYear;
                
        public int CompareTo(buyersguideApplication other)
        {// this function is use by Array.Sort() after all apps have been imported from the XML into memory
            int strCmpResults = 0;

            strCmpResults = string.Compare(this.part, other.part);
            if(strCmpResults > 0)
            {//partA > partB
                return (+1);
            }
            else
            {// partA <= partB
                if (strCmpResults == 0)
                {//partA == partB

                    strCmpResults = string.Compare(this.MakeName, other.MakeName);
                    if (strCmpResults > 0)
                    {//makeA > makeB
                        return (+1);
                    }
                    else
                    {//makeA <= makeB
                        if (strCmpResults == 0)
                        {//makeA == makeB
                            strCmpResults = string.Compare(this.ModelName, other.ModelName);
                            if (strCmpResults > 0)
                            {//modelA > modelB
                                return (+1);
                            }
                            else
                            {//modelA <= modelB
                                if (strCmpResults == 0)
                                {
                                    if (this.startYear > other.startYear)
                                    {
                                        return (+1);
                                    }
                                    else
                                    {// startyearA <= startyearB
                                        if(this.startYear == other.startYear)
                                        {
                                            return 0;
                                        }
                                        else
                                        {// startyearA < startyearB
                                            return (-1);
                                        }
                                    }
                                }
                                else
                                {//modelA < modelB
                                    return (-1);
                                }
                            }
                        }
                        else
                        {//makeA < makeB
                            return (-1);
                        }
                    }
                }
                else
                {// partA < partB
                    return (-1);
                }
            }
        }
        


    }


    public class BaseVehicle
    {
        public bool valid;
        public string MakeName;
        public string ModelName;
        public string YearId;
    }

    public class VCdbAttribute
    {// each one of these is a name/value pair that lives in an App. ex name="Submidel", value=13. A List of these (plus Notes) makes up the "qualifiers" for an App
        public string name;
        public int value;
    }


    public class ACES
    {// one of these holds the entire contents of the imported ACES file - along with the results of analysis. The methods for analysis are also here. the rationale for containerizing the imported data is for future 
        // development that might want to import/analyze/merge/split ACES datasets from/to seperate objects

        public bool analysisComplete = false;
        public bool successfulImport = false;
        public int analysisWarnings;
        public int analysisErrors;
        public string filePath;
        public string version;
        public string Company;
        public string SenderName;
        public string SenderPhone;
        public string TransferDate;
        public string BrandAAIAID;
        public string DocumentTitle;
        public string EffectiveDate;
        public string SubmissionType;
        public string VcdbVersionDate;
        public string QdbVersionDate;
        public string PcdbVersionDate;

        public App[] apps; // the actual size of the array gets defined when the ACES file is loaded
        public int appsCount = 0;
        public List<string> distinctParts = new List<string>();
        public Dictionary<string, int> partsAppsCounts = new Dictionary<string, int>();
        public Dictionary<string, string> partsPartTypes = new Dictionary<string, string>();
        public Dictionary<string, string> partsPositions = new Dictionary<string, string>();


        public List<int> distinctBasevids = new List<int>();
        public List<string> distinctAssets = new List<string>();
        public List<string> distinctMfrLabels = new List<string>();
        public List<int> distinctPartTypes = new List<int>();


        public List<string> parttypeDisagreementErrors = new List<string>();
        public List<string> duplicateErrors = new List<string>();
        public List<string> overlapsErrors = new List<string>();
        public List<string> CNCoverlapsErrors = new List<string>();
        public List<string> basevehicleidsErrors = new List<string>();
        public List<string> vcdbCodesErrors = new List<string>();
        public List<string> vcdbConfigurationsErrors = new List<string>();
        public List<string> parttypePositionErrors = new List<string>();
        public List<string> disperateAttributeErrors = new List<string>();
        public List<String> xmlValidationErrors = new List<string>();


        public Dictionary<String, String> ACESschemas = new Dictionary<string, string>();   // define as static so all instances of class can use same dictionary of XSD schema data


        public ACES()
        {// populate XSD's as strings in a string/string dictionary.

            ACESschemas.Add("1.08", "<?xml version =\"1.0\" encoding=\"UTF-8\"?><xs:schema xmlns:xs=\"http://www.w3.org/2001/XMLSchema\" elementFormDefault=\"qualified\"><xs:element name=\"ACES\"><xs:complexType><xs:sequence><xs:element ref=\"Header\"/><xs:element ref=\"App\" maxOccurs=\"unbounded\"/><xs:element ref=\"Footer\"/></xs:sequence><xs:attribute name=\"version\" type=\"xs:string\" use=\"required\"/></xs:complexType></xs:element><xs:element name=\"App\"><xs:complexType><xs:sequence><xs:choice><xs:sequence><xs:element ref=\"BaseVehicle\"/><xs:element ref=\"SubModel\" minOccurs=\"0\"/></xs:sequence><xs:sequence><xs:element ref=\"Years\"/><xs:element ref=\"Make\"/><xs:choice minOccurs=\"0\"><xs:element ref=\"VehicleType\"/><xs:sequence minOccurs=\"0\"><xs:element ref=\"Model\"/><xs:element ref=\"SubModel\" minOccurs=\"0\"/></xs:sequence></xs:choice></xs:sequence></xs:choice><xs:element ref=\"MfrBodyCode\" minOccurs=\"0\"/><xs:element ref=\"BodyNumDoors\" minOccurs=\"0\"/><xs:element ref=\"BodyType\" minOccurs=\"0\"/><xs:element ref=\"DriveType\" minOccurs=\"0\"/><xs:element ref=\"EngineBase\" minOccurs=\"0\"/><xs:element ref=\"EngineDesignation\" minOccurs=\"0\"/><xs:element ref=\"EngineVIN\" minOccurs=\"0\"/><xs:element ref=\"EngineVersion\" minOccurs=\"0\"/><xs:element ref=\"EngineMfr\" minOccurs=\"0\"/><xs:element ref=\"FuelDeliveryType\" minOccurs=\"0\"/><xs:element ref=\"FuelDeliverySubType\" minOccurs=\"0\"/><xs:element ref=\"FuelSystemControlType\" minOccurs=\"0\"/><xs:element ref=\"FuelSystemDesign\" minOccurs=\"0\"/><xs:element ref=\"Aspiration\" minOccurs=\"0\"/><xs:element ref=\"CylinderHeadType\" minOccurs=\"0\"/><xs:element ref=\"FuelType\" minOccurs=\"0\"/><xs:element ref=\"IgnitionSystemType\" minOccurs=\"0\"/><xs:element ref=\"TransmissionMfrCode\" minOccurs=\"0\"/><xs:choice minOccurs=\"0\"><xs:element ref=\"TransmissionBase\"/><xs:sequence><xs:element ref=\"TransmissionType\" minOccurs=\"0\"/><xs:element ref=\"TransmissionControlType\" minOccurs=\"0\"/><xs:element ref=\"TransmissionNumSpeeds\" minOccurs=\"0\"/></xs:sequence></xs:choice><xs:element ref=\"TransmissionMfr\" minOccurs=\"0\"/><xs:element ref=\"TransferCaseBase\" minOccurs=\"0\"/><xs:element ref=\"TransferCase\" minOccurs=\"0\"/><xs:element ref=\"TransferCaseMfr\" minOccurs=\"0\"/><xs:element ref=\"BedLength\" minOccurs=\"0\"/><xs:element ref=\"BedType\" minOccurs=\"0\"/><xs:element ref=\"WheelBase\" minOccurs=\"0\"/><xs:element ref=\"BrakeSystem\" minOccurs=\"0\"/><xs:element ref=\"FrontBrakeType\" minOccurs=\"0\"/><xs:element ref=\"RearBrakeType\" minOccurs=\"0\"/><xs:element ref=\"BrakeABS\" minOccurs=\"0\"/><xs:element ref=\"FrontSpringType\" minOccurs=\"0\"/><xs:element ref=\"RearSpringType\" minOccurs=\"0\"/><xs:element ref=\"SteeringSystem\" minOccurs=\"0\"/><xs:element ref=\"SteeringType\" minOccurs=\"0\"/><xs:element ref=\"RestraintType\" minOccurs=\"0\"/><xs:element ref=\"Region\" minOccurs=\"0\"/><xs:element ref=\"Note\" minOccurs=\"0\" maxOccurs=\"unbounded\"/><xs:element ref=\"Qty\"/><xs:element ref=\"PartType\"/><xs:element ref=\"MfrLabel\" minOccurs=\"0\"/><xs:element ref=\"Position\" minOccurs=\"0\"/><xs:element ref=\"Part\"/><xs:element ref=\"DisplayOrder\" minOccurs=\"0\"/></xs:sequence><xs:attribute name=\"action\" use=\"required\"><xs:simpleType><xs:restriction base=\"xs:NMTOKEN\"><xs:enumeration value=\"A\"/><xs:enumeration value=\"D\"/></xs:restriction></xs:simpleType></xs:attribute><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/><xs:attribute name=\"ref\" type=\"xs:string\"/></xs:complexType></xs:element><xs:element name=\"ApprovedFor\" type=\"xs:string\"/><xs:element name=\"Aspiration\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"BaseVehicle\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"BedLength\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"BedType\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"BodyNumDoors\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"BodyType\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"BrakeABS\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"BrakeSystem\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"Company\" type=\"xs:string\"/><xs:element name=\"CylinderHeadType\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"DisplayOrder\" type=\"xs:string\"/><xs:element name=\"DocFormNumber\" type=\"xs:string\"/><xs:element name=\"DocumentTitle\" type=\"xs:string\"/><xs:element name=\"DriveType\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"EffectiveDate\" type=\"xs:string\"/><xs:element name=\"EngineBase\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"EngineDesignation\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"EngineMfr\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"EngineVIN\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"EngineVersion\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"Footer\"><xs:complexType><xs:sequence><xs:element ref=\"RecordCount\"/></xs:sequence></xs:complexType></xs:element><xs:element name=\"FrontBrakeType\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"FrontSpringType\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"FuelDeliverySubType\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"FuelDeliveryType\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"FuelSystemControlType\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"FuelSystemDesign\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"FuelType\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"Header\"><xs:complexType><xs:sequence><xs:element ref=\"Company\"/><xs:element ref=\"SenderName\"/><xs:element ref=\"SenderPhone\"/><xs:element ref=\"SenderPhoneExt\" minOccurs=\"0\"/><xs:element ref=\"TransferDate\"/><xs:element ref=\"MfrCode\" minOccurs=\"0\"/><xs:element ref=\"DocumentTitle\"/><xs:element ref=\"DocFormNumber\" minOccurs=\"0\"/><xs:element ref=\"EffectiveDate\"/><xs:element ref=\"ApprovedFor\" minOccurs=\"0\"/><xs:element ref=\"SubmissionType\"/><xs:element ref=\"MapperCompany\" minOccurs=\"0\"/><xs:element ref=\"MapperContact\" minOccurs=\"0\"/><xs:element ref=\"MapperPhone\" minOccurs=\"0\"/><xs:element ref=\"MapperPhoneExt\" minOccurs=\"0\"/><xs:element ref=\"MapperEmail\" minOccurs=\"0\"/><xs:element ref=\"VcdbVersionDate\"/></xs:sequence></xs:complexType></xs:element><xs:element name=\"IgnitionSystemType\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"Make\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"MapperCompany\" type=\"xs:string\"/><xs:element name=\"MapperContact\" type=\"xs:string\"/><xs:element name=\"MapperEmail\" type=\"xs:string\"/><xs:element name=\"MapperPhone\" type=\"xs:string\"/><xs:element name=\"MapperPhoneExt\" type=\"xs:string\"/><xs:element name=\"MfrBodyCode\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"MfrCode\" type=\"xs:string\"/><xs:element name=\"MfrLabel\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"Model\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"Note\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/><xs:attribute name=\"lang\"><xs:simpleType><xs:restriction base=\"xs:NMTOKEN\"><xs:enumeration value=\"en\"/><xs:enumeration value=\"fr\"/><xs:enumeration value=\"sp\"/></xs:restriction></xs:simpleType></xs:attribute></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"Part\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"PartType\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"Position\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"Qty\" type=\"xs:string\"/><xs:element name=\"RearBrakeType\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"RearSpringType\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"RecordCount\" type=\"xs:string\"/><xs:element name=\"Region\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"RestraintType\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"SenderName\" type=\"xs:string\"/><xs:element name=\"SenderPhone\" type=\"xs:string\"/><xs:element name=\"SenderPhoneExt\" type=\"xs:string\"/><xs:element name=\"SteeringSystem\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"SteeringType\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"SubModel\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"SubmissionType\" type=\"xs:string\"/><xs:element name=\"TransferCase\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"TransferCaseBase\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"TransferCaseMfr\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"TransferDate\" type=\"xs:string\"/><xs:element name=\"TransmissionBase\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"TransmissionControlType\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"TransmissionMfr\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"TransmissionMfrCode\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"TransmissionNumSpeeds\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"TransmissionType\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"VcdbVersionDate\" type=\"xs:string\"/><xs:element name=\"VehicleType\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"WheelBase\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"Years\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"from\" type=\"xs:string\" use=\"required\"/><xs:attribute name=\"to\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element></xs:schema>");
            ACESschemas.Add("2.0", " <?xml version =\"1.0\" encoding=\"UTF-8\"?><xs:schema xmlns:xs=\"http://www.w3.org/2001/XMLSchema\" elementFormDefault=\"qualified\"><xs:element name=\"ACES\"><xs:complexType><xs:sequence><xs:element ref=\"Header\"/><xs:element ref=\"App\" maxOccurs=\"unbounded\"/><xs:element ref=\"Footer\"/></xs:sequence><xs:attribute name=\"version\" type=\"xs:string\" use=\"required\"/></xs:complexType></xs:element><xs:element name=\"App\"><xs:complexType><xs:sequence><xs:choice><xs:sequence><xs:element ref=\"BaseVehicle\"/><xs:element ref=\"SubModel\" minOccurs=\"0\"/></xs:sequence><xs:sequence><xs:element ref=\"Years\"/><xs:element ref=\"Make\"/><xs:choice minOccurs=\"0\"><xs:element ref=\"VehicleType\"/><xs:sequence minOccurs=\"0\"><xs:element ref=\"Model\"/><xs:element ref=\"SubModel\" minOccurs=\"0\"/></xs:sequence></xs:choice></xs:sequence></xs:choice><xs:element ref=\"MfrBodyCode\" minOccurs=\"0\"/><xs:element ref=\"BodyNumDoors\" minOccurs=\"0\"/><xs:element ref=\"BodyType\" minOccurs=\"0\"/><xs:element ref=\"DriveType\" minOccurs=\"0\"/><xs:element ref=\"EngineBase\" minOccurs=\"0\"/><xs:element ref=\"EngineDesignation\" minOccurs=\"0\"/><xs:element ref=\"EngineVIN\" minOccurs=\"0\"/><xs:element ref=\"EngineVersion\" minOccurs=\"0\"/><xs:element ref=\"EngineMfr\" minOccurs=\"0\"/><xs:element ref=\"ValvesPerEngine\" minOccurs=\"0\"/><xs:element ref=\"FuelDeliveryType\" minOccurs=\"0\"/><xs:element ref=\"FuelDeliverySubType\" minOccurs=\"0\"/><xs:element ref=\"FuelSystemControlType\" minOccurs=\"0\"/><xs:element ref=\"FuelSystemDesign\" minOccurs=\"0\"/><xs:element ref=\"Aspiration\" minOccurs=\"0\"/><xs:element ref=\"CylinderHeadType\" minOccurs=\"0\"/><xs:element ref=\"FuelType\" minOccurs=\"0\"/><xs:element ref=\"IgnitionSystemType\" minOccurs=\"0\"/><xs:element ref=\"TransmissionMfrCode\" minOccurs=\"0\"/><xs:choice minOccurs=\"0\"><xs:element ref=\"TransmissionBase\"/><xs:sequence><xs:element ref=\"TransmissionType\" minOccurs=\"0\"/><xs:element ref=\"TransmissionControlType\" minOccurs=\"0\"/><xs:element ref=\"TransmissionNumSpeeds\" minOccurs=\"0\"/></xs:sequence></xs:choice><xs:element ref=\"TransElecContolled\" minOccurs=\"0\"/><xs:element ref=\"TransmissionMfr\" minOccurs=\"0\"/><xs:element ref=\"TransferCaseBase\" minOccurs=\"0\"/><xs:element ref=\"TransferCase\" minOccurs=\"0\"/><xs:element ref=\"TransferCaseMfr\" minOccurs=\"0\"/><xs:element ref=\"BedLength\" minOccurs=\"0\"/><xs:element ref=\"BedType\" minOccurs=\"0\"/><xs:element ref=\"WheelBase\" minOccurs=\"0\"/><xs:element ref=\"BrakeSystem\" minOccurs=\"0\"/><xs:element ref=\"FrontBrakeType\" minOccurs=\"0\"/><xs:element ref=\"RearBrakeType\" minOccurs=\"0\"/><xs:element ref=\"BrakeABS\" minOccurs=\"0\"/><xs:element ref=\"FrontSpringType\" minOccurs=\"0\"/><xs:element ref=\"RearSpringType\" minOccurs=\"0\"/><xs:element ref=\"SteeringSystem\" minOccurs=\"0\"/><xs:element ref=\"SteeringType\" minOccurs=\"0\"/><xs:element ref=\"RestraintType\" minOccurs=\"0\"/><xs:element ref=\"Region\" minOccurs=\"0\"/><xs:element ref=\"Qual\" minOccurs=\"0\" maxOccurs=\"unbounded\"/><xs:element ref=\"Note\" minOccurs=\"0\" maxOccurs=\"unbounded\"/><xs:element ref=\"Qty\"/><xs:element ref=\"PartType\"/><xs:element ref=\"MfrLabel\" minOccurs=\"0\"/><xs:element ref=\"Position\" minOccurs=\"0\"/><xs:element ref=\"Part\"/><xs:element ref=\"DisplayOrder\" minOccurs=\"0\"/></xs:sequence><xs:attribute name=\"action\" use=\"required\"><xs:simpleType><xs:restriction base=\"xs:NMTOKEN\"><xs:enumeration value=\"A\"/><xs:enumeration value=\"D\"/></xs:restriction></xs:simpleType></xs:attribute><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/><xs:attribute name=\"ref\" type=\"xs:string\"/><xs:attribute name=\"validate\" default=\"yes\"><xs:simpleType><xs:restriction base=\"xs:NMTOKEN\"><xs:enumeration value=\"yes\"/><xs:enumeration value=\"no\"/></xs:restriction></xs:simpleType></xs:attribute></xs:complexType></xs:element><xs:element name=\"ApprovedFor\" type=\"xs:string\"/><xs:element name=\"Aspiration\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"BaseVehicle\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"BedLength\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"BedType\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"BodyNumDoors\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"BodyType\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"BrakeABS\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"BrakeSystem\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"Company\" type=\"xs:string\"/><xs:element name=\"CylinderHeadType\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"DisplayOrder\" type=\"xs:string\"/><xs:element name=\"DocFormNumber\" type=\"xs:string\"/><xs:element name=\"DocumentTitle\" type=\"xs:string\"/><xs:element name=\"DriveType\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"EffectiveDate\" type=\"xs:string\"/><xs:element name=\"EngineBase\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"EngineDesignation\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"EngineMfr\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"EngineVIN\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"EngineVersion\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"Footer\"><xs:complexType><xs:sequence><xs:element ref=\"RecordCount\"/></xs:sequence></xs:complexType></xs:element><xs:element name=\"FrontBrakeType\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"FrontSpringType\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"FuelDeliverySubType\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"FuelDeliveryType\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"FuelSystemControlType\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"FuelSystemDesign\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"FuelType\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"Header\"><xs:complexType><xs:sequence><xs:element ref=\"Company\"/><xs:element ref=\"SenderName\"/><xs:element ref=\"SenderPhone\"/><xs:element ref=\"SenderPhoneExt\" minOccurs=\"0\"/><xs:element ref=\"TransferDate\"/><xs:element ref=\"MfrCode\" minOccurs=\"0\"/><xs:element ref=\"DocumentTitle\"/><xs:element ref=\"DocFormNumber\" minOccurs=\"0\"/><xs:element ref=\"EffectiveDate\"/><xs:element ref=\"ApprovedFor\" minOccurs=\"0\"/><xs:element ref=\"SubmissionType\"/><xs:element ref=\"MapperCompany\" minOccurs=\"0\"/><xs:element ref=\"MapperContact\" minOccurs=\"0\"/><xs:element ref=\"MapperPhone\" minOccurs=\"0\"/><xs:element ref=\"MapperPhoneExt\" minOccurs=\"0\"/><xs:element ref=\"MapperEmail\" minOccurs=\"0\"/><xs:element ref=\"VcdbVersionDate\"/><xs:element ref=\"QdbVersionDate\"/><xs:element ref=\"PcdbVersionDate\"/></xs:sequence></xs:complexType></xs:element><xs:element name=\"IgnitionSystemType\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"Make\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"MapperCompany\" type=\"xs:string\"/><xs:element name=\"MapperContact\" type=\"xs:string\"/><xs:element name=\"MapperEmail\" type=\"xs:string\"/><xs:element name=\"MapperPhone\" type=\"xs:string\"/><xs:element name=\"MapperPhoneExt\" type=\"xs:string\"/><xs:element name=\"MfrBodyCode\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"MfrCode\" type=\"xs:string\"/><xs:element name=\"MfrLabel\" type=\"xs:string\"/><xs:element name=\"Model\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"Note\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\"/><xs:attribute name=\"lang\"><xs:simpleType><xs:restriction base=\"xs:NMTOKEN\"><xs:enumeration value=\"en\"/><xs:enumeration value=\"fr\"/><xs:enumeration value=\"sp\"/></xs:restriction></xs:simpleType></xs:attribute></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"Part\" type=\"xs:string\"/><xs:element name=\"PartType\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"PcdbVersionDate\"><xs:complexType/></xs:element><xs:element name=\"Position\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"QdbVersionDate\"><xs:complexType/></xs:element><xs:element name=\"Qty\" type=\"xs:string\"/><xs:element name=\"Qual\"><xs:complexType><xs:sequence><xs:element ref=\"param\" minOccurs=\"0\" maxOccurs=\"unbounded\"/><xs:element ref=\"text\"/></xs:sequence><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:complexType></xs:element><xs:element name=\"RearBrakeType\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"RearSpringType\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"RecordCount\" type=\"xs:string\"/><xs:element name=\"Region\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"RestraintType\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"SenderName\" type=\"xs:string\"/><xs:element name=\"SenderPhone\" type=\"xs:string\"/><xs:element name=\"SenderPhoneExt\" type=\"xs:string\"/><xs:element name=\"SteeringSystem\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"SteeringType\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"SubModel\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"SubmissionType\" type=\"xs:string\"/><xs:element name=\"TransElecContolled\"><xs:complexType/></xs:element><xs:element name=\"TransferCase\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"TransferCaseBase\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"TransferCaseMfr\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"TransferDate\" type=\"xs:string\"/><xs:element name=\"TransmissionBase\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"TransmissionControlType\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"TransmissionMfr\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"TransmissionMfrCode\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"TransmissionNumSpeeds\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"TransmissionType\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"ValvesPerEngine\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"VcdbVersionDate\" type=\"xs:string\"/><xs:element name=\"VehicleType\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"WheelBase\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"Years\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"from\" type=\"xs:string\" use=\"required\"/><xs:attribute name=\"to\" type=\"xs:string\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"param\"><xs:complexType><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"value\" type=\"xs:string\" use=\"required\"/><xs:attribute name=\"uom\" type=\"xs:string\"/><xs:attribute name=\"altvalue\" type=\"xs:string\"/><xs:attribute name=\"altuom\" type=\"xs:string\"/></xs:extension></xs:simpleContent></xs:complexType></xs:element><xs:element name=\"text\" type=\"xs:string\"/></xs:schema>");
            ACESschemas.Add("3.0", "<?xml version =\"1.0\" encoding=\"UTF-8\"?><xs:schema xmlns:xs=\"http://www.w3.org/2001/XMLSchema\" elementFormDefault=\"qualified\" xml:lang=\"en\" version=\"3.0\"><xs:annotation><xs:documentation>AAIA ACES xml schema version 3.0 for exchanging Automotive Aftermarket catalog application data.(c)2003-2009 AAIA All rights reserved. We do not enforce a default namespace or \"targetNamespace\" with this release to minimize the changes			required to existing instance documents and procedures.		</xs:documentation></xs:annotation><xs:simpleType name=\"acesVersionType\"><xs:annotation><xs:documentation source=\"http://www.xfront.com/Versioning.pdf\">Ties the instance document to a schema version.</xs:documentation></xs:annotation>   <xs:restriction base=\"xs:decimal\"><xs:enumeration value=\"1.0\"/><xs:enumeration value=\"2.0\"/><xs:enumeration value=\"3.0\"/></xs:restriction></xs:simpleType><xs:simpleType name=\"actionType\"><xs:restriction base=\"xs:NMTOKEN\"><xs:enumeration value=\"A\"/><xs:enumeration value=\"D\"/></xs:restriction></xs:simpleType><xs:simpleType name=\"assetNameType\"><xs:restriction base=\"xs:NMTOKEN\"><xs:minLength value=\"1\"/><xs:maxLength value=\"45\"/>			</xs:restriction></xs:simpleType><xs:simpleType name=\"brandType\"><xs:annotation><xs:documentation source=\"http://www.regular-expressions.info/xmlcharclass.html\">Ideally four uppercase chars without vowels but legacy included some vowels so we exclude just the ones necessary for each character position.</xs:documentation></xs:annotation>		<xs:restriction base=\"xs:string\"><xs:pattern value=\"[B-Z-[EIOU]][B-Z-[EIO]][B-Z-[OU]][A-Z]\"/></xs:restriction></xs:simpleType>	<xs:simpleType name=\"idType\"><xs:restriction base=\"xs:positiveInteger\"/></xs:simpleType><xs:simpleType name=\"partNumberBaseType\"><xs:restriction base=\"xs:token\"><xs:minLength value=\"0\"/><xs:maxLength value=\"45\"/></xs:restriction></xs:simpleType><xs:simpleType name=\"uomType\"><xs:restriction base=\"xs:NMTOKEN\"><xs:enumeration value=\"mm\"/><xs:enumeration value=\"cm\"/><xs:enumeration value=\"in\"/><xs:enumeration value=\"ft\"/>			<xs:enumeration value=\"mg\"/><xs:enumeration value=\"g\"/><xs:enumeration value=\"kg\"/><xs:enumeration value=\"oz\"/><xs:enumeration value=\"lb\"/><xs:enumeration value=\"ton\"/></xs:restriction></xs:simpleType> <xs:simpleType name=\"yearType\"><xs:restriction base=\"xs:positiveInteger\"><xs:minInclusive value=\"1896\"/><xs:maxInclusive value=\"2015\"/></xs:restriction></xs:simpleType><xs:simpleType name=\"yesnoType\"><xs:restriction base=\"xs:NMTOKEN\"><xs:enumeration value=\"yes\"/><xs:enumeration value=\"no\"/></xs:restriction></xs:simpleType><xs:complexType name=\"appItemsBaseType\" abstract=\"true\"><xs:sequence><xs:group   ref=\"vehicleIdentGroup\"/><xs:element ref=\"MfrBodyCode\" minOccurs=\"0\"/><xs:element ref=\"BodyNumDoors\" minOccurs=\"0\"/><xs:element ref=\"BodyType\" minOccurs=\"0\"/><xs:element ref=\"DriveType\" minOccurs=\"0\"/><xs:element ref=\"EngineBase\" minOccurs=\"0\"/><xs:element ref=\"EngineDesignation\" minOccurs=\"0\"/><xs:element ref=\"EngineVIN\" minOccurs=\"0\"/><xs:element ref=\"EngineVersion\" minOccurs=\"0\"/><xs:element ref=\"EngineMfr\" minOccurs=\"0\"/><xs:element ref=\"PowerOutput\" minOccurs=\"0\"/>			<xs:element ref=\"ValvesPerEngine\" minOccurs=\"0\"/><xs:element ref=\"FuelDeliveryType\" minOccurs=\"0\"/><xs:element ref=\"FuelDeliverySubType\" minOccurs=\"0\"/><xs:element ref=\"FuelSystemControlType\" minOccurs=\"0\"/><xs:element ref=\"FuelSystemDesign\" minOccurs=\"0\"/><xs:element ref=\"Aspiration\" minOccurs=\"0\"/><xs:element ref=\"CylinderHeadType\" minOccurs=\"0\"/><xs:element ref=\"FuelType\" minOccurs=\"0\"/><xs:element ref=\"IgnitionSystemType\" minOccurs=\"0\"/><xs:element ref=\"TransmissionMfrCode\" minOccurs=\"0\"/><xs:group   ref=\"transGroup\" minOccurs=\"0\"/><xs:element ref=\"TransElecControlled\" minOccurs=\"0\"/><xs:element ref=\"TransmissionMfr\" minOccurs=\"0\"/><xs:element ref=\"BedLength\" minOccurs=\"0\"/><xs:element ref=\"BedType\" minOccurs=\"0\"/><xs:element ref=\"WheelBase\" minOccurs=\"0\"/><xs:element ref=\"BrakeSystem\" minOccurs=\"0\"/><xs:element ref=\"FrontBrakeType\" minOccurs=\"0\"/><xs:element ref=\"RearBrakeType\" minOccurs=\"0\"/><xs:element ref=\"BrakeABS\" minOccurs=\"0\"/><xs:element ref=\"FrontSpringType\" minOccurs=\"0\"/><xs:element ref=\"RearSpringType\" minOccurs=\"0\"/><xs:element ref=\"SteeringSystem\" minOccurs=\"0\"/><xs:element ref=\"SteeringType\" minOccurs=\"0\"/><xs:element ref=\"Region\" minOccurs=\"0\"/><xs:element ref=\"Qual\" minOccurs=\"0\" maxOccurs=\"unbounded\"/><xs:element ref=\"Note\" minOccurs=\"0\" maxOccurs=\"unbounded\"/></xs:sequence><xs:attribute name=\"action\"   type=\"actionType\" use=\"required\"/><xs:attribute name=\"id\"       type=\"idType\" use=\"required\"/><xs:attribute name=\"ref\"      type=\"xs:string\"/><xs:attribute name=\"validate\" type=\"yesnoType\" default=\"yes\"/></xs:complexType>	<xs:complexType name=\"appType\"><xs:complexContent><xs:extension base=\"appItemsBaseType\"><xs:sequence><xs:element ref=\"Qty\"/><xs:element ref=\"PartType\"/><xs:element ref=\"MfrLabel\" minOccurs=\"0\"/><xs:element ref=\"Position\" minOccurs=\"0\"/><xs:element ref=\"Part\"/><xs:element ref=\"DisplayOrder\" minOccurs=\"0\"/><xs:sequence minOccurs=\"0\"><xs:element ref=\"AssetName\"/><xs:element ref=\"AssetItemOrder\" minOccurs=\"0\"/><xs:element ref=\"AssetItemRef\" minOccurs=\"0\"/></xs:sequence>					</xs:sequence></xs:extension></xs:complexContent></xs:complexType><xs:complexType name=\"assetType\"><xs:complexContent><xs:extension base=\"appItemsBaseType\"><xs:sequence><xs:element ref=\"AssetName\" minOccurs=\"1\"/></xs:sequence></xs:extension></xs:complexContent></xs:complexType>	<xs:complexType name=\"noteType\"><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"idType\"/><xs:attribute name=\"lang\"><xs:simpleType><xs:restriction base=\"xs:NMTOKEN\"><xs:enumeration value=\"en\"/><xs:enumeration value=\"fr\"/><xs:enumeration value=\"sp\"/></xs:restriction></xs:simpleType></xs:attribute></xs:extension></xs:simpleContent></xs:complexType><xs:complexType name=\"partNumberType\"><xs:simpleContent><xs:extension base=\"partNumberBaseType\"><xs:attribute name=\"BrandAAIAID\" type=\"brandType\"/></xs:extension></xs:simpleContent></xs:complexType><xs:complexType name=\"partTypeType\"><xs:annotation><xs:documentation source=\"http://www.aftermarket.org/aces3.0/#section_5.7.2\">A Part Type references the primary key in the Parts PCdb table.</xs:documentation></xs:annotation><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"idType\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType><xs:complexType name=\"positionType\"><xs:annotation><xs:documentation source=\"http://www.aftermarket.org/aces3.0/#section_5.7.14\">A Position references the primary key in the Position PCdb table.</xs:documentation></xs:annotation><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"idType\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType><xs:complexType name=\"qualType\"><xs:sequence><xs:element name=\"param\" type=\"paramType\" minOccurs=\"0\" maxOccurs=\"unbounded\"/><xs:element name=\"text\"  type=\"xs:string\"/></xs:sequence><xs:attribute name=\"id\" type=\"idType\" use=\"required\"/></xs:complexType><xs:complexType name=\"paramType\"><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"value\"    type=\"xs:string\" use=\"required\"/><xs:attribute name=\"uom\"      type=\"uomType\"/><xs:attribute name=\"altvalue\" type=\"xs:string\"/><xs:attribute name=\"altuom\"   type=\"uomType\"/></xs:extension></xs:simpleContent></xs:complexType><xs:complexType name=\"vehAttrType\"><xs:annotation><xs:documentation source=\"http://www.aftermarket.org/aces3.0/#section_5.7.5\">Vehicle Attributes reference the primary key in the associated VCdb table.</xs:documentation></xs:annotation>	<xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"idType\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType><xs:complexType name=\"yearRangeType\"><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"from\" type=\"yearType\" use=\"required\"/><xs:attribute name=\"to\"   type=\"yearType\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType><xs:element name=\"ACES\"><xs:complexType><xs:sequence><xs:element ref=\"Header\"/><xs:element ref=\"App\" minOccurs=\"0\" maxOccurs=\"unbounded\"/><xs:element ref=\"Asset\" minOccurs=\"0\" maxOccurs=\"unbounded\"/>				<xs:element ref=\"Footer\"/></xs:sequence><xs:attribute name=\"version\" type=\"acesVersionType\" use=\"required\"/></xs:complexType></xs:element><xs:element name=\"Header\"><xs:complexType><xs:sequence><xs:element name=\"Company\"         type=\"xs:string\"/><xs:element name=\"SenderName\"      type=\"xs:string\"/><xs:element name=\"SenderPhone\"     type=\"xs:string\"/><xs:element name=\"SenderPhoneExt\"  type=\"xs:string\" minOccurs=\"0\"/><xs:element name=\"TransferDate\"    type=\"xs:date\"/><xs:element name=\"MfrCode\"         type=\"xs:string\" minOccurs=\"0\"/><xs:element name=\"BrandAAIAID\"     type=\"brandType\" minOccurs=\"0\"/><xs:element name=\"DocumentTitle\"   type=\"xs:string\"/><xs:element name=\"DocFormNumber\"   type=\"xs:string\" minOccurs=\"0\"/><xs:element name=\"EffectiveDate\"   type=\"xs:date\"/><xs:element name=\"ApprovedFor\"     type=\"xs:string\" minOccurs=\"0\"/><xs:element name=\"SubmissionType\"  type=\"xs:string\"/><xs:element name=\"MapperCompany\"   type=\"xs:string\" minOccurs=\"0\"/><xs:element name=\"MapperContact\"   type=\"xs:string\" minOccurs=\"0\"/><xs:element name=\"MapperPhone\"     type=\"xs:string\" minOccurs=\"0\"/><xs:element name=\"MapperPhoneExt\"  type=\"xs:string\" minOccurs=\"0\"/><xs:element name=\"MapperEmail\"     type=\"xs:string\" minOccurs=\"0\"/><xs:element name=\"VcdbVersionDate\" type=\"xs:date\"/><xs:element name=\"QdbVersionDate\"  type=\"xs:date\"/><xs:element name=\"PcdbVersionDate\" type=\"xs:date\"/></xs:sequence></xs:complexType></xs:element>	<xs:group name=\"vehicleIdentGroup\"><xs:annotation><xs:documentation source=\"http://www.aftermarket.org/aces3.0/#section_5.7.1\">Either a Base Vehicle (which includes a year) or a Make / Year-Range combination must be included with each application.</xs:documentation></xs:annotation>	<xs:choice><xs:sequence><xs:element ref=\"BaseVehicle\"/><xs:element ref=\"SubModel\" minOccurs=\"0\"/></xs:sequence><xs:sequence><xs:element ref=\"Years\"/><xs:element ref=\"Make\"/><xs:choice minOccurs=\"0\"><xs:element ref=\"VehicleType\"/><xs:sequence minOccurs=\"0\"><xs:element ref=\"Model\"/><xs:element ref=\"SubModel\" minOccurs=\"0\"/></xs:sequence></xs:choice></xs:sequence></xs:choice>	</xs:group><xs:group name=\"transGroup\"><xs:choice><xs:element ref=\"TransmissionBase\"/><xs:sequence><xs:element ref=\"TransmissionType\" minOccurs=\"0\"/><xs:element ref=\"TransmissionControlType\" minOccurs=\"0\"/><xs:element ref=\"TransmissionNumSpeeds\" minOccurs=\"0\"/></xs:sequence></xs:choice></xs:group><xs:element name=\"App\"                     type=\"appType\"/><xs:element name=\"Aspiration\"              type=\"vehAttrType\"/><xs:element name=\"Asset\"                   type=\"assetType\"/><xs:element name=\"AssetItemOrder\"          type=\"xs:positiveInteger\"/><xs:element name=\"AssetItemRef\"            type=\"xs:string\"/>	<xs:element name=\"AssetName\"               type=\"assetNameType\"/><xs:element name=\"BaseVehicle\"             type=\"vehAttrType\"/><xs:element name=\"BedLength\"               type=\"vehAttrType\"/><xs:element name=\"BedType\"                 type=\"vehAttrType\"/><xs:element name=\"BodyNumDoors\"            type=\"vehAttrType\"/><xs:element name=\"BodyType\"                type=\"vehAttrType\"/><xs:element name=\"BrakeABS\"                type=\"vehAttrType\"/><xs:element name=\"BrakeSystem\"             type=\"vehAttrType\"/><xs:element name=\"CylinderHeadType\"        type=\"vehAttrType\"/><xs:element name=\"DisplayOrder\"            type=\"xs:positiveInteger\"/><xs:element name=\"DriveType\"               type=\"vehAttrType\"/><xs:element name=\"EngineBase\"              type=\"vehAttrType\"/><xs:element name=\"EngineDesignation\"       type=\"vehAttrType\"/><xs:element name=\"EngineMfr\"               type=\"vehAttrType\"/><xs:element name=\"EngineVIN\"               type=\"vehAttrType\"/><xs:element name=\"EngineVersion\"           type=\"vehAttrType\"/><xs:element name=\"FrontBrakeType\"          type=\"vehAttrType\"/><xs:element name=\"FrontSpringType\"         type=\"vehAttrType\"/><xs:element name=\"FuelDeliverySubType\"     type=\"vehAttrType\"/><xs:element name=\"FuelDeliveryType\"        type=\"vehAttrType\"/><xs:element name=\"FuelSystemControlType\"   type=\"vehAttrType\"/><xs:element name=\"FuelSystemDesign\"        type=\"vehAttrType\"/><xs:element name=\"FuelType\"                type=\"vehAttrType\"/><xs:element name=\"IgnitionSystemType\"      type=\"vehAttrType\"/><xs:element name=\"Make\"                    type=\"vehAttrType\"/><xs:element name=\"MfrBodyCode\"             type=\"vehAttrType\"/><xs:element name=\"MfrLabel\"                type=\"xs:string\"/><xs:element name=\"Model\"                   type=\"vehAttrType\"/><xs:element name=\"Note\"                    type=\"noteType\"/><xs:element name=\"Part\"                    type=\"partNumberType\"/><xs:element name=\"PartType\"                type=\"partTypeType\"/><xs:element name=\"Position\"                type=\"positionType\"/><xs:element name=\"PowerOutput\"             type=\"vehAttrType\"/>	<xs:element name=\"Qty\"                     type=\"xs:string\"/><xs:element name=\"Qual\"                    type=\"qualType\"/><xs:element name=\"RearBrakeType\"           type=\"vehAttrType\"/><xs:element name=\"RearSpringType\"          type=\"vehAttrType\"/><xs:element name=\"Region\"                  type=\"vehAttrType\"/><xs:element name=\"SteeringSystem\"          type=\"vehAttrType\"/><xs:element name=\"SteeringType\"            type=\"vehAttrType\"/><xs:element name=\"SubModel\"                type=\"vehAttrType\"/><xs:element name=\"TransElecControlled\"     type=\"vehAttrType\"/><xs:element name=\"TransferDate\"            type=\"xs:date\"/><xs:element name=\"TransmissionBase\"        type=\"vehAttrType\"/><xs:element name=\"TransmissionControlType\" type=\"vehAttrType\"/><xs:element name=\"TransmissionMfr\"         type=\"vehAttrType\"/><xs:element name=\"TransmissionMfrCode\"     type=\"vehAttrType\"/><xs:element name=\"TransmissionNumSpeeds\"   type=\"vehAttrType\"/><xs:element name=\"TransmissionType\"        type=\"vehAttrType\"/><xs:element name=\"ValvesPerEngine\"         type=\"vehAttrType\"/><xs:element name=\"VehicleType\"             type=\"vehAttrType\"/><xs:element name=\"WheelBase\"               type=\"vehAttrType\"/><xs:element name=\"Years\"                   type=\"yearRangeType\"/><xs:element name=\"Footer\"><xs:complexType><xs:sequence><xs:element name=\"RecordCount\" type=\"xs:string\"/></xs:sequence></xs:complexType></xs:element></xs:schema>");
            ACESschemas.Add("3.0.1", "<? xml version =\"1.0\" encoding=\"UTF-8\"?><xs:schema xmlns:xs=\"http://www.w3.org/2001/XMLSchema\" elementFormDefault=\"qualified\" version=\"3.0.1\" xml:lang=\"en\"><xs:annotation><xs:documentation>AAIA ACES xml schema version 3.0.1 for exchanging Automotive Aftermarket catalog application data.	(c)2003-2013 AAIA All rights reserved.	We do not enforce a default namespace or \"targetNamespace\" with this release to minimize the changes	required to existing instance documents and procedures.</xs:documentation></xs:annotation><xs:simpleType name=\"acesVersionType\"><xs:annotation><xs:documentation source=\"http://www.xfront.com/Versioning.pdf\">Ties the instance document to a schema version.</xs:documentation></xs:annotation><xs:restriction base=\"xs:string\"><xs:enumeration value=\"1.0\"/><xs:enumeration value=\"2.0\"/><xs:enumeration value=\"3.0\"/><xs:enumeration value=\"3.0.1\"/></xs:restriction></xs:simpleType><xs:simpleType name=\"actionType\"><xs:restriction base=\"xs:NMTOKEN\"><xs:enumeration value=\"A\"/><xs:enumeration value=\"D\"/></xs:restriction></xs:simpleType><xs:simpleType name=\"assetNameType\"><xs:restriction base=\"xs:NMTOKEN\"><xs:minLength value=\"1\"/><xs:maxLength value=\"45\"/></xs:restriction></xs:simpleType><xs:simpleType name=\"brandType\"><xs:annotation><xs:documentation source=\"http://www.regular-expressions.info/xmlcharclass.html\">Ideally four uppercase chars without vowels but legacy included some vowels so we	exclude just the ones necessary for each character position.</xs:documentation></xs:annotation><xs:restriction base=\"xs:string\"><xs:pattern value=\"[B-Z-[EIOU]][B-Z-[EIO]][B-Z-[OU]][A-Z]\"/></xs:restriction></xs:simpleType><xs:simpleType name=\"idType\"><xs:restriction base=\"xs:positiveInteger\"/></xs:simpleType><xs:simpleType name=\"partNumberBaseType\"><xs:restriction base=\"xs:token\"><xs:minLength value=\"0\"/><xs:maxLength value=\"45\"/></xs:restriction></xs:simpleType><xs:simpleType name=\"uomType\"><xs:restriction base=\"xs:NMTOKEN\"><xs:enumeration value=\"mm\"/><xs:enumeration value=\"cm\"/><xs:enumeration value=\"in\"/><xs:enumeration value=\"ft\"/><xs:enumeration value=\"mg\"/><xs:enumeration value=\"g\"/><xs:enumeration value=\"kg\"/><xs:enumeration value=\"oz\"/><xs:enumeration value=\"lb\"/><xs:enumeration value=\"ton\"/></xs:restriction></xs:simpleType><xs:simpleType name=\"yearType\"><xs:restriction base=\"xs:positiveInteger\"><xs:minInclusive value=\"1896\"/><xs:maxInclusive value=\"2015\"/></xs:restriction></xs:simpleType><xs:simpleType name=\"yesnoType\"><xs:restriction base=\"xs:NMTOKEN\"><xs:enumeration value=\"yes\"/><xs:enumeration value=\"no\"/></xs:restriction></xs:simpleType><xs:complexType name=\"appItemsBaseType\" abstract=\"true\"><xs:sequence><xs:group ref=\"vehicleIdentGroup\"/><xs:element ref=\"MfrBodyCode\" minOccurs=\"0\"/><xs:element ref=\"BodyNumDoors\" minOccurs=\"0\"/><xs:element ref=\"BodyType\" minOccurs=\"0\"/><xs:element ref=\"DriveType\" minOccurs=\"0\"/><xs:element ref=\"EngineBase\" minOccurs=\"0\"/><xs:element ref=\"EngineDesignation\" minOccurs=\"0\"/><xs:element ref=\"EngineVIN\" minOccurs=\"0\"/><xs:element ref=\"EngineVersion\" minOccurs=\"0\"/><xs:element ref=\"EngineMfr\" minOccurs=\"0\"/><xs:element ref=\"PowerOutput\" minOccurs=\"0\"/><xs:element ref=\"ValvesPerEngine\" minOccurs=\"0\"/><xs:element ref=\"FuelDeliveryType\" minOccurs=\"0\"/><xs:element ref=\"FuelDeliverySubType\" minOccurs=\"0\"/><xs:element ref=\"FuelSystemControlType\" minOccurs=\"0\"/><xs:element ref=\"FuelSystemDesign\" minOccurs=\"0\"/><xs:element ref=\"Aspiration\" minOccurs=\"0\"/><xs:element ref=\"CylinderHeadType\" minOccurs=\"0\"/><xs:element ref=\"FuelType\" minOccurs=\"0\"/><xs:element ref=\"IgnitionSystemType\" minOccurs=\"0\"/><xs:element ref=\"TransmissionMfrCode\" minOccurs=\"0\"/><xs:group ref=\"transGroup\" minOccurs=\"0\"/><xs:element ref=\"TransElecControlled\" minOccurs=\"0\"/><xs:element ref=\"TransmissionMfr\" minOccurs=\"0\"/><xs:element ref=\"BedLength\" minOccurs=\"0\"/><xs:element ref=\"BedType\" minOccurs=\"0\"/><xs:element ref=\"WheelBase\" minOccurs=\"0\"/><xs:element ref=\"BrakeSystem\" minOccurs=\"0\"/><xs:element ref=\"FrontBrakeType\" minOccurs=\"0\"/><xs:element ref=\"RearBrakeType\" minOccurs=\"0\"/><xs:element ref=\"BrakeABS\" minOccurs=\"0\"/><xs:element ref=\"FrontSpringType\" minOccurs=\"0\"/><xs:element ref=\"RearSpringType\" minOccurs=\"0\"/><xs:element ref=\"SteeringSystem\" minOccurs=\"0\"/><xs:element ref=\"SteeringType\" minOccurs=\"0\"/><xs:element ref=\"Region\" minOccurs=\"0\"/><xs:element ref=\"Qual\" minOccurs=\"0\" maxOccurs=\"unbounded\"/><xs:element ref=\"Note\" minOccurs=\"0\" maxOccurs=\"unbounded\"/></xs:sequence><xs:attribute name=\"action\" type=\"actionType\" use=\"required\"/><xs:attribute name=\"id\" type=\"idType\" use=\"required\"/><xs:attribute name=\"ref\" type=\"xs:string\"/><xs:attribute name=\"validate\" type=\"yesnoType\" default=\"yes\"/></xs:complexType><xs:complexType name=\"appType\"><xs:complexContent><xs:extension base=\"appItemsBaseType\"><xs:sequence><xs:element ref=\"Qty\"/><xs:element ref=\"PartType\"/><xs:element ref=\"MfrLabel\" minOccurs=\"0\"/><xs:element ref=\"Position\" minOccurs=\"0\"/><xs:element ref=\"Part\"/><xs:element ref=\"DisplayOrder\" minOccurs=\"0\"/><xs:sequence minOccurs=\"0\"><xs:element ref=\"AssetName\"/><xs:element ref=\"AssetItemOrder\" minOccurs=\"0\"/><xs:element ref=\"AssetItemRef\" minOccurs=\"0\"/></xs:sequence></xs:sequence></xs:extension></xs:complexContent></xs:complexType><xs:complexType name=\"assetType\"><xs:complexContent><xs:extension base=\"appItemsBaseType\"><xs:sequence><xs:element ref=\"AssetName\" minOccurs=\"1\"/></xs:sequence></xs:extension></xs:complexContent></xs:complexType><xs:complexType name=\"noteType\"><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"idType\"/><xs:attribute name=\"lang\"><xs:simpleType><xs:restriction base=\"xs:NMTOKEN\"><xs:enumeration value=\"en\"/><xs:enumeration value=\"fr\"/><xs:enumeration value=\"sp\"/></xs:restriction></xs:simpleType></xs:attribute></xs:extension></xs:simpleContent></xs:complexType><xs:complexType name=\"partNumberType\"><xs:simpleContent><xs:extension base=\"partNumberBaseType\"><xs:attribute name=\"BrandAAIAID\" type=\"brandType\"/></xs:extension></xs:simpleContent></xs:complexType><xs:complexType name=\"partTypeType\"><xs:annotation><xs:documentation source=\"http://www.aftermarket.org/aces3.0/#section_5.7.2\">A Part Type references the primary key in the Parts PCdb table.</xs:documentation></xs:annotation><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"idType\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType><xs:complexType name=\"positionType\"><xs:annotation><xs:documentation source=\"http://www.aftermarket.org/aces3.0/#section_5.7.14\">A Position references the primary key in the Position PCdb table.</xs:documentation></xs:annotation><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"idType\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType><xs:complexType name=\"qualType\"><xs:sequence><xs:element name=\"param\" type=\"paramType\" minOccurs=\"0\" maxOccurs=\"unbounded\"/><xs:element name=\"text\" type=\"xs:string\"/></xs:sequence><xs:attribute name=\"id\" type=\"idType\" use=\"required\"/></xs:complexType><xs:complexType name=\"paramType\"><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"value\" type=\"xs:string\" use=\"required\"/><xs:attribute name=\"uom\" type=\"uomType\"/><xs:attribute name=\"altvalue\" type=\"xs:string\"/><xs:attribute name=\"altuom\" type=\"uomType\"/></xs:extension></xs:simpleContent></xs:complexType><xs:complexType name=\"vehAttrType\"><xs:annotation><xs:documentation source=\"http://www.aftermarket.org/aces3.0/#section_5.7.5\">Vehicle Attributes reference the primary key in the associated VCdb table.</xs:documentation></xs:annotation><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"idType\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType><xs:complexType name=\"yearRangeType\"><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"from\" type=\"yearType\" use=\"required\"/><xs:attribute name=\"to\" type=\"yearType\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType><xs:element name=\"ACES\"><xs:complexType><xs:sequence><xs:element ref=\"Header\"/><xs:element ref=\"App\" minOccurs=\"0\" maxOccurs=\"unbounded\"/><xs:element ref=\"Asset\" minOccurs=\"0\" maxOccurs=\"unbounded\"/><xs:element ref=\"Footer\"/></xs:sequence><xs:attribute name=\"version\" type=\"acesVersionType\" use=\"required\"/></xs:complexType></xs:element><xs:element name=\"Header\"><xs:complexType><xs:sequence><xs:element name=\"Company\" type=\"xs:string\"/><xs:element name=\"SenderName\" type=\"xs:string\"/><xs:element name=\"SenderPhone\" type=\"xs:string\"/><xs:element name=\"SenderPhoneExt\" type=\"xs:string\" minOccurs=\"0\"/><xs:element name=\"TransferDate\" type=\"xs:date\"/><xs:element name=\"MfrCode\" type=\"xs:string\" minOccurs=\"0\"/><xs:element name=\"BrandAAIAID\" type=\"brandType\" minOccurs=\"0\"/><xs:element name=\"DocumentTitle\" type=\"xs:string\"/><xs:element name=\"DocFormNumber\" type=\"xs:string\" minOccurs=\"0\"/><xs:element name=\"EffectiveDate\" type=\"xs:date\"/><xs:element name=\"ApprovedFor\" type=\"xs:string\" minOccurs=\"0\"/><xs:element name=\"SubmissionType\" type=\"xs:string\"/><xs:element name=\"MapperCompany\" type=\"xs:string\" minOccurs=\"0\"/><xs:element name=\"MapperContact\" type=\"xs:string\" minOccurs=\"0\"/><xs:element name=\"MapperPhone\" type=\"xs:string\" minOccurs=\"0\"/><xs:element name=\"MapperPhoneExt\" type=\"xs:string\" minOccurs=\"0\"/><xs:element name=\"MapperEmail\" type=\"xs:string\" minOccurs=\"0\"/><xs:element name=\"VcdbVersionDate\" type=\"xs:date\"/><xs:element name=\"QdbVersionDate\" type=\"xs:date\"/><xs:element name=\"PcdbVersionDate\" type=\"xs:date\"/></xs:sequence></xs:complexType></xs:element><xs:group name=\"vehicleIdentGroup\"><xs:annotation><xs:documentation source=\"http://www.aftermarket.org/aces3.0/#section_5.7.1\">Either a Base Vehicle (which includes a year) or a Make / Year-Range combination	must be included with each application. </xs:documentation></xs:annotation><xs:choice><xs:sequence><xs:element ref=\"BaseVehicle\"/><xs:element ref=\"SubModel\" minOccurs=\"0\"/></xs:sequence><xs:sequence><xs:element ref=\"Years\"/><xs:element ref=\"Make\"/><xs:choice minOccurs=\"0\"><xs:element ref=\"VehicleType\"/><xs:sequence minOccurs=\"0\"><xs:element ref=\"Model\"/><xs:element ref=\"SubModel\" minOccurs=\"0\"/></xs:sequence></xs:choice></xs:sequence></xs:choice></xs:group><xs:group name=\"transGroup\"><xs:choice><xs:element ref=\"TransmissionBase\"/><xs:sequence><xs:element ref=\"TransmissionType\" minOccurs=\"0\"/><xs:element ref=\"TransmissionControlType\" minOccurs=\"0\"/><xs:element ref=\"TransmissionNumSpeeds\" minOccurs=\"0\"/></xs:sequence></xs:choice></xs:group><xs:element name=\"App\" type=\"appType\"/><xs:element name=\"Aspiration\" type=\"vehAttrType\"/><xs:element name=\"Asset\" type=\"assetType\"/><xs:element name=\"AssetItemOrder\" type=\"xs:positiveInteger\"/><xs:element name=\"AssetItemRef\" type=\"xs:string\"/><xs:element name=\"AssetName\" type=\"assetNameType\"/><xs:element name=\"BaseVehicle\" type=\"vehAttrType\"/><xs:element name=\"BedLength\" type=\"vehAttrType\"/><xs:element name=\"BedType\" type=\"vehAttrType\"/><xs:element name=\"BodyNumDoors\" type=\"vehAttrType\"/><xs:element name=\"BodyType\" type=\"vehAttrType\"/><xs:element name=\"BrakeABS\" type=\"vehAttrType\"/><xs:element name=\"BrakeSystem\" type=\"vehAttrType\"/><xs:element name=\"CylinderHeadType\" type=\"vehAttrType\"/><xs:element name=\"DisplayOrder\" type=\"xs:positiveInteger\"/><xs:element name=\"DriveType\" type=\"vehAttrType\"/><xs:element name=\"EngineBase\" type=\"vehAttrType\"/><xs:element name=\"EngineDesignation\" type=\"vehAttrType\"/><xs:element name=\"EngineMfr\" type=\"vehAttrType\"/><xs:element name=\"EngineVIN\" type=\"vehAttrType\"/><xs:element name=\"EngineVersion\" type=\"vehAttrType\"/><xs:element name=\"FrontBrakeType\" type=\"vehAttrType\"/><xs:element name=\"FrontSpringType\" type=\"vehAttrType\"/><xs:element name=\"FuelDeliverySubType\" type=\"vehAttrType\"/><xs:element name=\"FuelDeliveryType\" type=\"vehAttrType\"/><xs:element name=\"FuelSystemControlType\" type=\"vehAttrType\"/><xs:element name=\"FuelSystemDesign\" type=\"vehAttrType\"/><xs:element name=\"FuelType\" type=\"vehAttrType\"/><xs:element name=\"IgnitionSystemType\" type=\"vehAttrType\"/><xs:element name=\"Make\" type=\"vehAttrType\"/><xs:element name=\"MfrBodyCode\" type=\"vehAttrType\"/><xs:element name=\"MfrLabel\" type=\"xs:string\"/><xs:element name=\"Model\" type=\"vehAttrType\"/><xs:element name=\"Note\" type=\"noteType\"/><xs:element name=\"Part\" type=\"partNumberType\"/><xs:element name=\"PartType\" type=\"partTypeType\"/><xs:element name=\"Position\" type=\"positionType\"/><xs:element name=\"PowerOutput\" type=\"vehAttrType\"/><xs:element name=\"Qty\" type=\"xs:string\"/><xs:element name=\"Qual\" type=\"qualType\"/><xs:element name=\"RearBrakeType\" type=\"vehAttrType\"/><xs:element name=\"RearSpringType\" type=\"vehAttrType\"/><xs:element name=\"Region\" type=\"vehAttrType\"/><xs:element name=\"SteeringSystem\" type=\"vehAttrType\"/><xs:element name=\"SteeringType\" type=\"vehAttrType\"/><xs:element name=\"SubModel\" type=\"vehAttrType\"/><xs:element name=\"TransElecControlled\" type=\"vehAttrType\"/><xs:element name=\"TransferDate\" type=\"xs:date\"/><xs:element name=\"TransmissionBase\" type=\"vehAttrType\"/><xs:element name=\"TransmissionControlType\" type=\"vehAttrType\"/><xs:element name=\"TransmissionMfr\" type=\"vehAttrType\"/><xs:element name=\"TransmissionMfrCode\" type=\"vehAttrType\"/><xs:element name=\"TransmissionNumSpeeds\" type=\"vehAttrType\"/><xs:element name=\"TransmissionType\" type=\"vehAttrType\"/><xs:element name=\"ValvesPerEngine\" type=\"vehAttrType\"/><xs:element name=\"VehicleType\" type=\"vehAttrType\"/><xs:element name=\"WheelBase\" type=\"vehAttrType\"/><xs:element name=\"Years\" type=\"yearRangeType\"/><xs:element name=\"Footer\"><xs:complexType><xs:sequence><xs:element name=\"RecordCount\" type=\"xs:string\"/></xs:sequence></xs:complexType></xs:element></xs:schema>");
            ACESschemas.Add("3.1", "<?xml version=\"1.0\" encoding=\"UTF-8\"?><xs:schema xmlns:xs=\"http://www.w3.org/2001/XMLSchema\" elementFormDefault=\"qualified\" version=\"3.1\" xml:lang=\"en\"><xs:annotation><xs:documentation>AAIA ACES xml schema version 3.1 for exchanging Automotive Aftermarket catalog application data.	(c)2003-2013 AAIA All rights reserved.	We do not enforce a default namespace or \"targetNamespace\" with this release to minimize the changes	required to existing instance documents and procedures.</xs:documentation></xs:annotation><xs:simpleType name=\"acesVersionType\"><xs:annotation><xs:documentation source=\"http://www.xfront.com/Versioning.pdf\">Ties the instance document to a schema version.</xs:documentation></xs:annotation><xs:restriction base=\"xs:string\"><xs:enumeration value=\"1.0\"/><xs:enumeration value=\"2.0\"/><xs:enumeration value=\"3.0\"/><xs:enumeration value=\"3.0.1\"/><xs:enumeration value=\"3.1\"/></xs:restriction></xs:simpleType><xs:simpleType name=\"actionType\"><xs:restriction base=\"xs:NMTOKEN\"><xs:enumeration value=\"A\"/><xs:enumeration value=\"D\"/></xs:restriction></xs:simpleType><xs:simpleType name=\"assetNameType\"><xs:restriction base=\"xs:NMTOKEN\"><xs:minLength value=\"1\"/><xs:maxLength value=\"45\"/></xs:restriction></xs:simpleType><xs:simpleType name=\"brandType\"><xs:annotation><xs:documentation source=\"http://www.regular-expressions.info/xmlcharclass.html\">Ideally four uppercase chars without vowels but legacy included some vowels so we	exclude just the ones necessary for each character position.</xs:documentation></xs:annotation><xs:restriction base=\"xs:string\"><xs:pattern value=\"[B-Z-[EIOU]][B-Z-[EIO]][B-Z-[OU]][A-Z]\"/></xs:restriction></xs:simpleType><xs:simpleType name=\"idType\"><xs:restriction base=\"xs:positiveInteger\"/></xs:simpleType><xs:simpleType name=\"partNumberBaseType\"><xs:restriction base=\"xs:token\"><xs:minLength value=\"0\"/><xs:maxLength value=\"45\"/></xs:restriction></xs:simpleType><xs:simpleType name=\"uomType\"><xs:restriction base=\"xs:NMTOKEN\"><xs:enumeration value=\"mm\"/><xs:enumeration value=\"cm\"/><xs:enumeration value=\"in\"/><xs:enumeration value=\"ft\"/><xs:enumeration value=\"mg\"/><xs:enumeration value=\"g\"/><xs:enumeration value=\"kg\"/><xs:enumeration value=\"oz\"/><xs:enumeration value=\"lb\"/><xs:enumeration value=\"ton\"/></xs:restriction></xs:simpleType><xs:simpleType name=\"yearType\"><xs:restriction base=\"xs:positiveInteger\"><xs:minInclusive value=\"1896\"/><xs:maxInclusive value=\"2015\"/></xs:restriction></xs:simpleType><xs:simpleType name=\"yesnoType\"><xs:restriction base=\"xs:NMTOKEN\"><xs:enumeration value=\"yes\"/><xs:enumeration value=\"no\"/></xs:restriction></xs:simpleType><xs:complexType name=\"appItemsBaseType\" abstract=\"true\"><xs:sequence><xs:group ref=\"vehicleIdentGroup\"/><xs:element ref=\"MfrBodyCode\" minOccurs=\"0\"/><xs:element ref=\"BodyNumDoors\" minOccurs=\"0\"/><xs:element ref=\"BodyType\" minOccurs=\"0\"/><xs:element ref=\"DriveType\" minOccurs=\"0\"/><xs:element ref=\"EngineBase\" minOccurs=\"0\"/><xs:element ref=\"EngineDesignation\" minOccurs=\"0\"/><xs:element ref=\"EngineVIN\" minOccurs=\"0\"/><xs:element ref=\"EngineVersion\" minOccurs=\"0\"/><xs:element ref=\"EngineMfr\" minOccurs=\"0\"/><xs:element ref=\"PowerOutput\" minOccurs=\"0\"/><xs:element ref=\"ValvesPerEngine\" minOccurs=\"0\"/><xs:element ref=\"FuelDeliveryType\" minOccurs=\"0\"/><xs:element ref=\"FuelDeliverySubType\" minOccurs=\"0\"/><xs:element ref=\"FuelSystemControlType\" minOccurs=\"0\"/><xs:element ref=\"FuelSystemDesign\" minOccurs=\"0\"/><xs:element ref=\"Aspiration\" minOccurs=\"0\"/><xs:element ref=\"CylinderHeadType\" minOccurs=\"0\"/><xs:element ref=\"FuelType\" minOccurs=\"0\"/><xs:element ref=\"IgnitionSystemType\" minOccurs=\"0\"/><xs:element ref=\"TransmissionMfrCode\" minOccurs=\"0\"/><xs:group ref=\"transGroup\" minOccurs=\"0\"/><xs:element ref=\"TransElecControlled\" minOccurs=\"0\"/><xs:element ref=\"TransmissionMfr\" minOccurs=\"0\"/><xs:element ref=\"BedLength\" minOccurs=\"0\"/><xs:element ref=\"BedType\" minOccurs=\"0\"/><xs:element ref=\"WheelBase\" minOccurs=\"0\"/><xs:element ref=\"BrakeSystem\" minOccurs=\"0\"/><xs:element ref=\"FrontBrakeType\" minOccurs=\"0\"/><xs:element ref=\"RearBrakeType\" minOccurs=\"0\"/><xs:element ref=\"BrakeABS\" minOccurs=\"0\"/><xs:element ref=\"FrontSpringType\" minOccurs=\"0\"/><xs:element ref=\"RearSpringType\" minOccurs=\"0\"/><xs:element ref=\"SteeringSystem\" minOccurs=\"0\"/><xs:element ref=\"SteeringType\" minOccurs=\"0\"/><xs:element ref=\"Region\" minOccurs=\"0\"/><xs:element ref=\"Qual\" minOccurs=\"0\" maxOccurs=\"unbounded\"/><xs:element ref=\"Note\" minOccurs=\"0\" maxOccurs=\"unbounded\"/></xs:sequence><xs:attribute name=\"action\" type=\"actionType\" use=\"required\"/><xs:attribute name=\"id\" type=\"idType\" use=\"required\"/><xs:attribute name=\"ref\" type=\"xs:string\"/><xs:attribute name=\"validate\" type=\"yesnoType\" default=\"yes\"/></xs:complexType><xs:complexType name=\"appType\"><xs:complexContent><xs:extension base=\"appItemsBaseType\"><xs:sequence><xs:element ref=\"Qty\"/><xs:element ref=\"PartType\"/><xs:element ref=\"MfrLabel\" minOccurs=\"0\"/><xs:element ref=\"Position\" minOccurs=\"0\"/><xs:element ref=\"Part\"/><xs:element ref=\"DisplayOrder\" minOccurs=\"0\"/><xs:sequence minOccurs=\"0\"><xs:element ref=\"AssetName\"/><xs:element ref=\"AssetItemOrder\" minOccurs=\"0\"/><xs:element ref=\"AssetItemRef\" minOccurs=\"0\"/></xs:sequence></xs:sequence></xs:extension></xs:complexContent></xs:complexType><xs:complexType name=\"assetType\"><xs:complexContent><xs:extension base=\"appItemsBaseType\"><xs:sequence><xs:element ref=\"AssetName\" minOccurs=\"1\"/></xs:sequence></xs:extension></xs:complexContent></xs:complexType><xs:complexType name=\"noteType\"><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"idType\"/><xs:attribute name=\"lang\"><xs:simpleType><xs:restriction base=\"xs:NMTOKEN\"><xs:enumeration value=\"en\"/><xs:enumeration value=\"fr\"/><xs:enumeration value=\"sp\"/></xs:restriction></xs:simpleType></xs:attribute></xs:extension></xs:simpleContent></xs:complexType><xs:complexType name=\"partNumberType\"><xs:simpleContent><xs:extension base=\"partNumberBaseType\"><xs:attribute name=\"BrandAAIAID\" type=\"brandType\"/></xs:extension></xs:simpleContent></xs:complexType><xs:complexType name=\"partTypeType\"><xs:annotation><xs:documentation source=\"http://www.aftermarket.org/aces3.0/#section_5.7.2\">A Part Type references the primary key in the Parts PCdb table.</xs:documentation></xs:annotation><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"idType\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType><xs:complexType name=\"positionType\"><xs:annotation><xs:documentation source=\"http://www.aftermarket.org/aces3.0/#section_5.7.14\">A Position references the primary key in the Position PCdb table.</xs:documentation></xs:annotation><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"idType\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType><xs:complexType name=\"qualType\"><xs:sequence><xs:element name=\"param\" type=\"paramType\" minOccurs=\"0\" maxOccurs=\"unbounded\"/><xs:element name=\"text\" type=\"xs:string\"/></xs:sequence><xs:attribute name=\"id\" type=\"idType\" use=\"required\"/></xs:complexType><xs:complexType name=\"paramType\"><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"value\" type=\"xs:string\" use=\"required\"/><xs:attribute name=\"uom\" type=\"uomType\"/><xs:attribute name=\"altvalue\" type=\"xs:string\"/><xs:attribute name=\"altuom\" type=\"uomType\"/></xs:extension></xs:simpleContent></xs:complexType><xs:complexType name=\"vehAttrType\"><xs:annotation><xs:documentation source=\"http://www.aftermarket.org/aces3.0/#section_5.7.5\">Vehicle Attributes reference the primary key in the associated VCdb table.</xs:documentation></xs:annotation><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"idType\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType><xs:complexType name=\"yearRangeType\"><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"from\" type=\"yearType\" use=\"required\"/><xs:attribute name=\"to\" type=\"yearType\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType><xs:element name=\"ACES\"><xs:complexType><xs:sequence><xs:element ref=\"Header\"/><xs:element ref=\"App\" minOccurs=\"0\" maxOccurs=\"unbounded\"/><xs:element ref=\"Asset\" minOccurs=\"0\" maxOccurs=\"unbounded\"/><xs:element ref=\"Footer\"/></xs:sequence><xs:attribute name=\"version\" type=\"acesVersionType\" use=\"required\"/></xs:complexType></xs:element><xs:element name=\"Header\"><xs:complexType><xs:sequence><xs:element name=\"Company\" type=\"xs:string\"/><xs:element name=\"SenderName\" type=\"xs:string\"/><xs:element name=\"SenderPhone\" type=\"xs:string\"/><xs:element name=\"SenderPhoneExt\" type=\"xs:string\" minOccurs=\"0\"/><xs:element name=\"TransferDate\" type=\"xs:date\"/><xs:element name=\"MfrCode\" type=\"xs:string\" minOccurs=\"0\"/><xs:element name=\"BrandAAIAID\" type=\"brandType\" minOccurs=\"0\"/><xs:element name=\"DocumentTitle\" type=\"xs:string\"/><xs:element name=\"DocFormNumber\" type=\"xs:string\" minOccurs=\"0\"/><xs:element name=\"EffectiveDate\" type=\"xs:date\"/><xs:element name=\"ApprovedFor\" type=\"xs:string\" minOccurs=\"0\"/><xs:element name=\"SubmissionType\" type=\"xs:string\"/><xs:element name=\"MapperCompany\" type=\"xs:string\" minOccurs=\"0\"/><xs:element name=\"MapperContact\" type=\"xs:string\" minOccurs=\"0\"/><xs:element name=\"MapperPhone\" type=\"xs:string\" minOccurs=\"0\"/><xs:element name=\"MapperPhoneExt\" type=\"xs:string\" minOccurs=\"0\"/><xs:element name=\"MapperEmail\" type=\"xs:string\" minOccurs=\"0\"/><xs:element name=\"VcdbVersionDate\" type=\"xs:date\"/><xs:element name=\"QdbVersionDate\" type=\"xs:date\"/><xs:element name=\"PcdbVersionDate\" type=\"xs:date\"/></xs:sequence></xs:complexType></xs:element><xs:group name=\"vehicleIdentGroup\"><xs:annotation><xs:documentation source=\"http://www.aftermarket.org/aces3.0/#section_5.7.1\">Either a Base Vehicle (which includes a year) or a Make / Year-Range combination	must be included with each application. </xs:documentation></xs:annotation><xs:choice><xs:sequence><xs:element ref=\"BaseVehicle\"/><xs:element ref=\"SubModel\" minOccurs=\"0\"/></xs:sequence><xs:sequence><xs:element ref=\"Years\"/><xs:element ref=\"Make\"/><xs:choice minOccurs=\"0\"><xs:element ref=\"VehicleType\"/><xs:sequence minOccurs=\"0\"><xs:element ref=\"Model\"/><xs:element ref=\"SubModel\" minOccurs=\"0\"/></xs:sequence></xs:choice></xs:sequence></xs:choice></xs:group><xs:group name=\"transGroup\"><xs:choice><xs:element ref=\"TransmissionBase\"/><xs:sequence><xs:element ref=\"TransmissionType\" minOccurs=\"0\"/><xs:element ref=\"TransmissionControlType\" minOccurs=\"0\"/><xs:element ref=\"TransmissionNumSpeeds\" minOccurs=\"0\"/></xs:sequence></xs:choice></xs:group><xs:element name=\"App\" type=\"appType\"/><xs:element name=\"Aspiration\" type=\"vehAttrType\"/><xs:element name=\"Asset\" type=\"assetType\"/><xs:element name=\"AssetItemOrder\" type=\"xs:positiveInteger\"/><xs:element name=\"AssetItemRef\" type=\"xs:string\"/><xs:element name=\"AssetName\" type=\"assetNameType\"/><xs:element name=\"BaseVehicle\" type=\"vehAttrType\"/><xs:element name=\"BedLength\" type=\"vehAttrType\"/><xs:element name=\"BedType\" type=\"vehAttrType\"/><xs:element name=\"BodyNumDoors\" type=\"vehAttrType\"/><xs:element name=\"BodyType\" type=\"vehAttrType\"/><xs:element name=\"BrakeABS\" type=\"vehAttrType\"/><xs:element name=\"BrakeSystem\" type=\"vehAttrType\"/><xs:element name=\"CylinderHeadType\" type=\"vehAttrType\"/><xs:element name=\"DisplayOrder\" type=\"xs:positiveInteger\"/><xs:element name=\"DriveType\" type=\"vehAttrType\"/><xs:element name=\"EngineBase\" type=\"vehAttrType\"/><xs:element name=\"EngineDesignation\" type=\"vehAttrType\"/><xs:element name=\"EngineMfr\" type=\"vehAttrType\"/><xs:element name=\"EngineVIN\" type=\"vehAttrType\"/><xs:element name=\"EngineVersion\" type=\"vehAttrType\"/><xs:element name=\"FrontBrakeType\" type=\"vehAttrType\"/><xs:element name=\"FrontSpringType\" type=\"vehAttrType\"/><xs:element name=\"FuelDeliverySubType\" type=\"vehAttrType\"/><xs:element name=\"FuelDeliveryType\" type=\"vehAttrType\"/><xs:element name=\"FuelSystemControlType\" type=\"vehAttrType\"/><xs:element name=\"FuelSystemDesign\" type=\"vehAttrType\"/><xs:element name=\"FuelType\" type=\"vehAttrType\"/><xs:element name=\"IgnitionSystemType\" type=\"vehAttrType\"/><xs:element name=\"Make\" type=\"vehAttrType\"/><xs:element name=\"MfrBodyCode\" type=\"vehAttrType\"/><xs:element name=\"MfrLabel\" type=\"xs:string\"/><xs:element name=\"Model\" type=\"vehAttrType\"/><xs:element name=\"Note\" type=\"noteType\"/><xs:element name=\"Part\" type=\"partNumberType\"/><xs:element name=\"PartType\" type=\"partTypeType\"/><xs:element name=\"Position\" type=\"positionType\"/><xs:element name=\"PowerOutput\" type=\"vehAttrType\"/><xs:element name=\"Qty\" type=\"xs:string\"/><xs:element name=\"Qual\" type=\"qualType\"/><xs:element name=\"RearBrakeType\" type=\"vehAttrType\"/><xs:element name=\"RearSpringType\" type=\"vehAttrType\"/><xs:element name=\"Region\" type=\"vehAttrType\"/><xs:element name=\"SteeringSystem\" type=\"vehAttrType\"/><xs:element name=\"SteeringType\" type=\"vehAttrType\"/><xs:element name=\"SubModel\" type=\"vehAttrType\"/><xs:element name=\"TransElecControlled\" type=\"vehAttrType\"/><xs:element name=\"TransferDate\" type=\"xs:date\"/><xs:element name=\"TransmissionBase\" type=\"vehAttrType\"/><xs:element name=\"TransmissionControlType\" type=\"vehAttrType\"/><xs:element name=\"TransmissionMfr\" type=\"vehAttrType\"/><xs:element name=\"TransmissionMfrCode\" type=\"vehAttrType\"/><xs:element name=\"TransmissionNumSpeeds\" type=\"vehAttrType\"/><xs:element name=\"TransmissionType\" type=\"vehAttrType\"/><xs:element name=\"ValvesPerEngine\" type=\"vehAttrType\"/><xs:element name=\"VehicleType\" type=\"vehAttrType\"/><xs:element name=\"WheelBase\" type=\"vehAttrType\"/><xs:element name=\"Years\" type=\"yearRangeType\"/><xs:element name=\"Footer\"><xs:complexType><xs:sequence><xs:element name=\"RecordCount\" type=\"xs:string\"/></xs:sequence></xs:complexType></xs:element></xs:schema>");
            ACESschemas.Add("3.2", "<?xml version=\"1.0\" encoding=\"UTF-8\"?><xs:schema xmlns:xs=\"http://www.w3.org/2001/XMLSchema\" elementFormDefault=\"qualified\" version=\"3.2\" xml:lang=\"en\"><xs:annotation><xs:documentation>Auto Care Assocation ACES xml schema version 3.2 for exchanging catalog application data.	(c)2003-2016 Auto Care Assocation All rights reserved.	We do not enforce a default namespace or \"targetNamespace\" with this release to minimize the changes	required to existing instance documents and procedures.</xs:documentation></xs:annotation><!-- simple type definitions --><xs:simpleType name=\"acesVersionType\"><xs:annotation><xs:documentation source=\"http://www.xfront.com/Versioning.pdf\">Ties the instance document to a schema version.</xs:documentation></xs:annotation><xs:restriction base=\"xs:string\"><xs:enumeration value=\"1.0\"/><xs:enumeration value=\"2.0\"/><xs:enumeration value=\"3.0\"/><xs:enumeration value=\"3.0.1\"/><xs:enumeration value=\"3.1\"/><xs:enumeration value=\"3.2\"/></xs:restriction></xs:simpleType><xs:simpleType name=\"actionType\"><xs:restriction base=\"xs:NMTOKEN\"><xs:enumeration value=\"A\"/><xs:enumeration value=\"D\"/></xs:restriction></xs:simpleType><xs:simpleType name=\"assetNameType\"><xs:restriction base=\"xs:NMTOKEN\"><xs:minLength value=\"1\"/><xs:maxLength value=\"45\"/></xs:restriction></xs:simpleType><xs:simpleType name=\"brandType\"><xs:annotation><xs:documentation source=\"http://www.regular-expressions.info/xmlcharclass.html\">Ideally four uppercase chars without vowels but legacy included some vowels so we	exclude just the ones necessary for each character position.</xs:documentation></xs:annotation><xs:restriction base=\"xs:string\"><xs:pattern value=\"[B-Z-[EIOU]][B-Z-[EIO]][B-Z-[OU]][A-Z]\"/></xs:restriction></xs:simpleType><xs:simpleType name=\"idType\"><xs:restriction base=\"xs:positiveInteger\"/></xs:simpleType><xs:simpleType name=\"partNumberBaseType\"><xs:restriction base=\"xs:token\"><xs:minLength value=\"0\"/><xs:maxLength value=\"45\"/></xs:restriction></xs:simpleType><xs:simpleType name=\"uomType\"><xs:restriction base=\"xs:NMTOKEN\"><xs:enumeration value=\"mm\"/><xs:enumeration value=\"cm\"/><xs:enumeration value=\"in\"/><xs:enumeration value=\"ft\"/><xs:enumeration value=\"mg\"/><xs:enumeration value=\"g\"/><xs:enumeration value=\"kg\"/><xs:enumeration value=\"oz\"/><xs:enumeration value=\"lb\"/><xs:enumeration value=\"ton\"/></xs:restriction></xs:simpleType><xs:simpleType name=\"yearType\"><xs:restriction base=\"xs:positiveInteger\"><xs:totalDigits value=\"4\"/><xs:minInclusive value=\"1896\"/></xs:restriction></xs:simpleType><xs:simpleType name=\"yesnoType\"><xs:restriction base=\"xs:NMTOKEN\"><xs:enumeration value=\"yes\"/><xs:enumeration value=\"no\"/></xs:restriction></xs:simpleType><!-- complex type definitions --><xs:complexType name=\"appItemsBaseType\" abstract=\"true\"><xs:sequence><xs:group ref=\"vehicleIdentGroup\"/><xs:element ref=\"MfrBodyCode\" minOccurs=\"0\"/><xs:element ref=\"BodyNumDoors\" minOccurs=\"0\"/><xs:element ref=\"BodyType\" minOccurs=\"0\"/><xs:element ref=\"DriveType\" minOccurs=\"0\"/><xs:element ref=\"EngineBase\" minOccurs=\"0\"/><xs:element ref=\"EngineDesignation\" minOccurs=\"0\"/><xs:element ref=\"EngineVIN\" minOccurs=\"0\"/><xs:element ref=\"EngineVersion\" minOccurs=\"0\"/><xs:element ref=\"EngineMfr\" minOccurs=\"0\"/><xs:element ref=\"PowerOutput\" minOccurs=\"0\"/><xs:element ref=\"ValvesPerEngine\" minOccurs=\"0\"/><xs:element ref=\"FuelDeliveryType\" minOccurs=\"0\"/><xs:element ref=\"FuelDeliverySubType\" minOccurs=\"0\"/><xs:element ref=\"FuelSystemControlType\" minOccurs=\"0\"/><xs:element ref=\"FuelSystemDesign\" minOccurs=\"0\"/><xs:element ref=\"Aspiration\" minOccurs=\"0\"/><xs:element ref=\"CylinderHeadType\" minOccurs=\"0\"/><xs:element ref=\"FuelType\" minOccurs=\"0\"/><xs:element ref=\"IgnitionSystemType\" minOccurs=\"0\"/><xs:element ref=\"TransmissionMfrCode\" minOccurs=\"0\"/><xs:group ref=\"transGroup\" minOccurs=\"0\"/><xs:element ref=\"TransElecControlled\" minOccurs=\"0\"/><xs:element ref=\"TransmissionMfr\" minOccurs=\"0\"/><xs:element ref=\"BedLength\" minOccurs=\"0\"/><xs:element ref=\"BedType\" minOccurs=\"0\"/><xs:element ref=\"WheelBase\" minOccurs=\"0\"/><xs:element ref=\"BrakeSystem\" minOccurs=\"0\"/><xs:element ref=\"FrontBrakeType\" minOccurs=\"0\"/><xs:element ref=\"RearBrakeType\" minOccurs=\"0\"/><xs:element ref=\"BrakeABS\" minOccurs=\"0\"/><xs:element ref=\"FrontSpringType\" minOccurs=\"0\"/><xs:element ref=\"RearSpringType\" minOccurs=\"0\"/><xs:element ref=\"SteeringSystem\" minOccurs=\"0\"/><xs:element ref=\"SteeringType\" minOccurs=\"0\"/><xs:element ref=\"Region\" minOccurs=\"0\"/><xs:element ref=\"Qual\" minOccurs=\"0\" maxOccurs=\"unbounded\"/><xs:element ref=\"Note\" minOccurs=\"0\" maxOccurs=\"unbounded\"/></xs:sequence><xs:attribute name=\"action\" type=\"actionType\" use=\"required\"/><xs:attribute name=\"id\" type=\"idType\" use=\"required\"/><xs:attribute name=\"ref\" type=\"xs:string\"/><xs:attribute name=\"validate\" type=\"yesnoType\" default=\"yes\"/></xs:complexType><xs:complexType name=\"appType\"><xs:complexContent><xs:extension base=\"appItemsBaseType\"><xs:sequence><xs:element ref=\"Qty\"/><xs:element ref=\"PartType\"/><xs:element ref=\"MfrLabel\" minOccurs=\"0\"/><xs:element ref=\"Position\" minOccurs=\"0\"/><xs:element ref=\"Part\"/><xs:element ref=\"DisplayOrder\" minOccurs=\"0\"/><xs:sequence minOccurs=\"0\"><xs:element ref=\"AssetName\"/><xs:element ref=\"AssetItemOrder\" minOccurs=\"0\"/><xs:element ref=\"AssetItemRef\" minOccurs=\"0\"/></xs:sequence></xs:sequence></xs:extension></xs:complexContent></xs:complexType><xs:complexType name=\"assetType\"><xs:complexContent><xs:extension base=\"appItemsBaseType\"/></xs:complexContent></xs:complexType><xs:complexType name=\"noteType\"><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"idType\"/><xs:attribute name=\"lang\"><xs:simpleType><xs:restriction base=\"xs:NMTOKEN\"><xs:enumeration value=\"en\"/><xs:enumeration value=\"fr\"/><xs:enumeration value=\"sp\"/></xs:restriction></xs:simpleType></xs:attribute></xs:extension></xs:simpleContent></xs:complexType><xs:complexType name=\"partNumberType\"><xs:simpleContent><xs:extension base=\"partNumberBaseType\"><xs:attribute name=\"BrandAAIAID\" type=\"brandType\"/></xs:extension></xs:simpleContent></xs:complexType><xs:complexType name=\"partTypeType\"><xs:annotation><xs:documentation>A Part Type references the primary key in the Parts PCdb table.</xs:documentation></xs:annotation><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"idType\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType><xs:complexType name=\"positionType\"><xs:annotation><xs:documentation>A Position references the primary key in the Position PCdb table.</xs:documentation></xs:annotation><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"idType\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType><xs:complexType name=\"qualType\"><xs:sequence><xs:element name=\"param\" type=\"paramType\" minOccurs=\"0\" maxOccurs=\"unbounded\"/><xs:element name=\"text\" type=\"xs:string\"/></xs:sequence><xs:attribute name=\"id\" type=\"idType\" use=\"required\"/></xs:complexType><xs:complexType name=\"paramType\"><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"value\" type=\"xs:string\" use=\"required\"/><xs:attribute name=\"uom\" type=\"uomType\"/><xs:attribute name=\"altvalue\" type=\"xs:string\"/><xs:attribute name=\"altuom\" type=\"uomType\"/></xs:extension></xs:simpleContent></xs:complexType><xs:complexType name=\"vehAttrType\"><xs:annotation><xs:documentation>Vehicle Attributes reference the primary key in the associated VCdb table.</xs:documentation></xs:annotation><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"id\" type=\"idType\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType><xs:complexType name=\"yearRangeType\"><xs:simpleContent><xs:extension base=\"xs:string\"><xs:attribute name=\"from\" use=\"required\"><xs:simpleType><xs:restriction base=\"yearType\"/></xs:simpleType></xs:attribute><xs:attribute name=\"to\" type=\"yearType\" use=\"required\"/></xs:extension></xs:simpleContent></xs:complexType><!-- document structure --><xs:element name=\"ACES\"><xs:complexType><xs:sequence><xs:element ref=\"Header\"/><xs:element ref=\"App\" minOccurs=\"0\" maxOccurs=\"unbounded\"/><xs:element ref=\"Asset\" minOccurs=\"0\" maxOccurs=\"unbounded\"/><xs:element ref=\"DigitalAsset\" minOccurs=\"0\" maxOccurs=\"1\"/><xs:element ref=\"Footer\"/></xs:sequence><xs:attribute name=\"version\" type=\"acesVersionType\" use=\"required\"/></xs:complexType></xs:element><!-- \"Header\" element definition --><xs:element name=\"Header\"><xs:complexType><xs:sequence><xs:element name=\"Company\" type=\"xs:string\"/><xs:element name=\"SenderName\" type=\"xs:string\"/><xs:element name=\"SenderPhone\" type=\"xs:string\"/><xs:element name=\"SenderPhoneExt\" type=\"xs:string\" minOccurs=\"0\"/><xs:element name=\"TransferDate\" type=\"xs:date\"/><xs:element name=\"MfrCode\" type=\"xs:string\" minOccurs=\"0\"/><xs:element name=\"BrandAAIAID\" type=\"brandType\" minOccurs=\"0\"/><xs:element name=\"DocumentTitle\" type=\"xs:string\"/><xs:element name=\"DocFormNumber\" type=\"xs:string\" minOccurs=\"0\"/><xs:element name=\"EffectiveDate\" type=\"xs:date\"/><xs:element name=\"ApprovedFor\" type=\"approvedForType\" minOccurs=\"0\"/><xs:element name=\"SubmissionType\" type=\"xs:string\"/><xs:element name=\"MapperCompany\" type=\"xs:string\" minOccurs=\"0\"/><xs:element name=\"MapperContact\" type=\"xs:string\" minOccurs=\"0\"/><xs:element name=\"MapperPhone\" type=\"xs:string\" minOccurs=\"0\"/><xs:element name=\"MapperPhoneExt\" type=\"xs:string\" minOccurs=\"0\"/><xs:element name=\"MapperEmail\" type=\"xs:string\" minOccurs=\"0\"/><xs:element name=\"VcdbVersionDate\" type=\"xs:date\"/><xs:element name=\"QdbVersionDate\" type=\"xs:date\"/><xs:element name=\"PcdbVersionDate\" type=\"xs:date\"/></xs:sequence></xs:complexType></xs:element><!-- Vehicle Identification Group definition --><xs:group name=\"vehicleIdentGroup\"><xs:annotation><xs:documentation>Either a Base Vehicle (which includes a year) or a Make / Year-Range combination	must be included with each application. </xs:documentation></xs:annotation><xs:choice><xs:sequence><xs:element ref=\"BaseVehicle\"/><xs:element ref=\"SubModel\" minOccurs=\"0\"/></xs:sequence><xs:sequence><xs:element ref=\"Years\"/><xs:element ref=\"Make\"/><xs:choice minOccurs=\"0\"><xs:element ref=\"VehicleType\"/><xs:sequence minOccurs=\"0\"><xs:element ref=\"Model\"/><xs:element ref=\"SubModel\" minOccurs=\"0\"/></xs:sequence></xs:choice></xs:sequence></xs:choice></xs:group><!-- Transmission Group dfinition --><xs:group name=\"transGroup\"><xs:choice><xs:element ref=\"TransmissionBase\"/><xs:sequence><xs:element ref=\"TransmissionType\" minOccurs=\"0\"/><xs:element ref=\"TransmissionControlType\" minOccurs=\"0\"/><xs:element ref=\"TransmissionNumSpeeds\" minOccurs=\"0\"/></xs:sequence></xs:choice></xs:group><!-- element definitions  --><xs:element name=\"App\" type=\"appType\"/><xs:element name=\"Aspiration\" type=\"vehAttrType\"/><xs:element name=\"Asset\"><xs:complexType><xs:complexContent><xs:extension base=\"assetType\"><xs:sequence><xs:element ref=\"AssetName\"/></xs:sequence></xs:extension></xs:complexContent></xs:complexType></xs:element><xs:element name=\"AssetItemOrder\" type=\"xs:positiveInteger\"/><xs:element name=\"AssetItemRef\" type=\"xs:string\"/><xs:element name=\"AssetName\" type=\"assetNameType\"/><xs:element name=\"BaseVehicle\" type=\"vehAttrType\"/><xs:element name=\"BedLength\" type=\"vehAttrType\"/><xs:element name=\"BedType\" type=\"vehAttrType\"/><xs:element name=\"BodyNumDoors\" type=\"vehAttrType\"/><xs:element name=\"BodyType\" type=\"vehAttrType\"/><xs:element name=\"BrakeABS\" type=\"vehAttrType\"/><xs:element name=\"BrakeSystem\" type=\"vehAttrType\"/><xs:element name=\"CylinderHeadType\" type=\"vehAttrType\"/><xs:element name=\"DisplayOrder\" type=\"xs:positiveInteger\"/><xs:element name=\"DriveType\" type=\"vehAttrType\"/><xs:element name=\"EngineBase\" type=\"vehAttrType\"/><xs:element name=\"EngineDesignation\" type=\"vehAttrType\"/><xs:element name=\"EngineMfr\" type=\"vehAttrType\"/><xs:element name=\"EngineVIN\" type=\"vehAttrType\"/><xs:element name=\"EngineVersion\" type=\"vehAttrType\"/><xs:element name=\"FrontBrakeType\" type=\"vehAttrType\"/><xs:element name=\"FrontSpringType\" type=\"vehAttrType\"/><xs:element name=\"FuelDeliverySubType\" type=\"vehAttrType\"/><xs:element name=\"FuelDeliveryType\" type=\"vehAttrType\"/><xs:element name=\"FuelSystemControlType\" type=\"vehAttrType\"/><xs:element name=\"FuelSystemDesign\" type=\"vehAttrType\"/><xs:element name=\"FuelType\" type=\"vehAttrType\"/><xs:element name=\"IgnitionSystemType\" type=\"vehAttrType\"/><xs:element name=\"Make\" type=\"vehAttrType\"/><xs:element name=\"MfrBodyCode\" type=\"vehAttrType\"/><xs:element name=\"MfrLabel\" type=\"xs:string\"/><xs:element name=\"Model\" type=\"vehAttrType\"/><xs:element name=\"Note\" type=\"noteType\"/><xs:element name=\"Part\" type=\"partNumberType\"/><xs:element name=\"PartType\" type=\"partTypeType\"/><xs:element name=\"Position\" type=\"positionType\"/><xs:element name=\"PowerOutput\" type=\"vehAttrType\"/><xs:element name=\"Qty\" type=\"xs:string\"/><xs:element name=\"Qual\" type=\"qualType\"/><xs:element name=\"RearBrakeType\" type=\"vehAttrType\"/><xs:element name=\"RearSpringType\" type=\"vehAttrType\"/><xs:element name=\"Region\" type=\"vehAttrType\"/><xs:element name=\"SteeringSystem\" type=\"vehAttrType\"/><xs:element name=\"SteeringType\" type=\"vehAttrType\"/><xs:element name=\"SubModel\" type=\"vehAttrType\"/><xs:element name=\"TransElecControlled\" type=\"vehAttrType\"/><xs:element name=\"TransferDate\" type=\"xs:date\"/><xs:element name=\"TransmissionBase\" type=\"vehAttrType\"/><xs:element name=\"TransmissionControlType\" type=\"vehAttrType\"/><xs:element name=\"TransmissionMfr\" type=\"vehAttrType\"/><xs:element name=\"TransmissionMfrCode\" type=\"vehAttrType\"/><xs:element name=\"TransmissionNumSpeeds\" type=\"vehAttrType\"/><xs:element name=\"TransmissionType\" type=\"vehAttrType\"/><xs:element name=\"ValvesPerEngine\" type=\"vehAttrType\"/><xs:element name=\"VehicleType\" type=\"vehAttrType\"/><xs:element name=\"WheelBase\" type=\"vehAttrType\"/><xs:element name=\"Years\" type=\"yearRangeType\"/><xs:complexType name=\"approvedForType\"><xs:sequence><xs:element name=\"Country\" maxOccurs=\"unbounded\"><xs:simpleType><xs:restriction base=\"xs:token\"><xs:length value=\"2\"/></xs:restriction></xs:simpleType></xs:element></xs:sequence></xs:complexType><xs:element name=\"DigitalAsset\"><xs:complexType><xs:sequence><xs:element name=\"DigitalFileInformation\" type=\"digitalFileInformationType\" minOccurs=\"1\" maxOccurs=\"unbounded\"/></xs:sequence></xs:complexType></xs:element><xs:complexType name=\"digitalFileInformationType\"><xs:sequence><xs:element name=\"FileName\"><xs:simpleType><xs:restriction base=\"xs:string\"><xs:minLength value=\"1\"/><xs:maxLength value=\"80\"/></xs:restriction></xs:simpleType></xs:element><xs:element name=\"AssetDetailType\" type=\"assetDetailType\"/><xs:element name=\"FileType\" minOccurs=\"0\"><xs:simpleType><xs:restriction base=\"assetFileType\"><xs:maxLength value=\"4\"/><xs:minLength value=\"3\"/></xs:restriction></xs:simpleType></xs:element><xs:element name=\"Representation\" type=\"representationType\" minOccurs=\"0\"/><xs:element name=\"FileSize\" minOccurs=\"0\"><xs:simpleType><xs:restriction base=\"xs:positiveInteger\"><xs:totalDigits value=\"10\"/></xs:restriction></xs:simpleType></xs:element><xs:element name=\"Resolution\" type=\"resolutionType\" minOccurs=\"0\"/><xs:element name=\"ColorMode\" type=\"colorModeType\" minOccurs=\"0\"/><xs:element name=\"Background\" type=\"backgroundType\" minOccurs=\"0\"/><xs:element name=\"OrientationView\" type=\"orientationViewType\" minOccurs=\"0\"/><xs:element name=\"AssetDimensions\" minOccurs=\"0\"><xs:complexType><xs:sequence><xs:element name=\"AssetHeight\" minOccurs=\"0\"><xs:simpleType><xs:restriction base=\"xs:decimal\"><xs:minExclusive value=\"0\"/><xs:totalDigits value=\"6\"/><xs:fractionDigits value=\"4\"/></xs:restriction></xs:simpleType></xs:element><xs:element name=\"AssetWidth\" minOccurs=\"0\"><xs:simpleType><xs:restriction base=\"xs:decimal\"><xs:minExclusive value=\"0\"/><xs:totalDigits value=\"6\"/><xs:fractionDigits value=\"4\"/></xs:restriction></xs:simpleType></xs:element></xs:sequence><xs:attribute name=\"UOM\" type=\"dimensionUOMType\" use=\"required\"/></xs:complexType></xs:element><xs:element name=\"AssetDescription\" type=\"xs:string\" minOccurs=\"0\"/><xs:element name=\"FilePath\" minOccurs=\"0\"><xs:simpleType><xs:restriction base=\"xs:string\"><xs:minLength value=\"1\"/><xs:maxLength value=\"80\"/></xs:restriction></xs:simpleType></xs:element><xs:element name=\"URI\" minOccurs=\"0\"><xs:simpleType><xs:restriction base=\"xs:anyURI\"><xs:maxLength value=\"2000\"/></xs:restriction></xs:simpleType></xs:element><xs:element name=\"FileDateModified\" type=\"xs:date\" minOccurs=\"0\"/><xs:element name=\"EffectiveDate\" type=\"xs:date\" minOccurs=\"0\"/><xs:element name=\"ExpirationDate\" type=\"xs:date\" minOccurs=\"0\"/><xs:element name=\"Country\" minOccurs=\"0\"><xs:simpleType><xs:restriction base=\"xs:token\"><xs:length value=\"2\"/></xs:restriction></xs:simpleType></xs:element></xs:sequence><xs:attribute name=\"AssetName\" use=\"required\"/><xs:attribute name=\"action\" type=\"actionType\" use=\"required\"/><xs:attribute name=\"LanguageCode\" type=\"xs:string\"/></xs:complexType><xs:simpleType name=\"assetDetailType\"><xs:annotation><xs:documentation>Code	Description	360		360 Degree Image Set	APG		Application Guide	AUD		Audio File	BRO		Brochure	BUL		Technical Bulletin	BUY		Buyers Guide	CAS		Case Study	CAT		Catalog	CER		Certificate of Origin	DAS		Datasheet	DRW	Technical Drawing	EBK		Ebook	FAB		Features and Benefits	FED		Full Engineering Drawing 	HMS		Hazardous Materials Info Sheet	INS		Installation Instructions	ISG		Illustration Guide	LIN		Line Art	LGO		Logo Image	MSD		Material Safety Data Sheet	OWN	Owner's Manual	P01		Photo – out of package	P02		Photo – in package	P03		Photo – lifestyle view	P04		Photo - Primary	P05		Photo - Close Up	P06		Photo - Mounted	P07		Photo - Unmounted	PAG		Link To Manufacturer Page	PAL		Pallet Configuration Drawing	PDB		Product Brochure	PC1		Planogram Consumer Pack 1	PC2		Planogram Consumer Pack 2	PC3		Planogram Consumer Pack 3	PI1		Planogram Inner Pack 1	PI2		Planogram Inner Pack 2	PI3		Planogram Inner Pack 3	PP1		Planogram Case Pack 1	PP2		Planogram Case Pack 2	PP3		Planogram Case Pack 3	PSS		Product Specifications Sheet	PST		Price Sheet	RES		Research Bulletin	SPE		Specification Sheet Filename 	THU		Thumbnail	TON		Tone Art	WAR	Warranty	MHP		Whitepaper	ZZ1	User 1	ZZ2	User 2	ZZ3	User 3	ZZ4	User 4	ZZ5	User 5	ZZ6	User 6	ZZ7	User 7	ZZ8	User 8	ZZ9	User 9</xs:documentation></xs:annotation><xs:restriction base=\"xs:string\"><xs:enumeration value=\"360\"/><xs:enumeration value=\"APG\"/><xs:enumeration value=\"AUD\"/><xs:enumeration value=\"BRO\"/><xs:enumeration value=\"BUL\"/><xs:enumeration value=\"BUY\"/><xs:enumeration value=\"CAS\"/><xs:enumeration value=\"CAT\"/><xs:enumeration value=\"CER\"/><xs:enumeration value=\"DAS\"/><xs:enumeration value=\"DRW\"/><xs:enumeration value=\"EBK\"/><xs:enumeration value=\"FAB\"/><xs:enumeration value=\"FED\"/><xs:enumeration value=\"HMS\"/><xs:enumeration value=\"INS\"/><xs:enumeration value=\"ISG\"/><xs:enumeration value=\"LIN\"/><xs:enumeration value=\"LGO\"/><xs:enumeration value=\"MSD\"/><xs:enumeration value=\"OWN\"/><xs:enumeration value=\"P01\"/><xs:enumeration value=\"P02\"/><xs:enumeration value=\"P03\"/><xs:enumeration value=\"P04\"/><xs:enumeration value=\"P05\"/><xs:enumeration value=\"P06\"/><xs:enumeration value=\"P07\"/><xs:enumeration value=\"PAG\"/><xs:enumeration value=\"PAL\"/><xs:enumeration value=\"PDB\"/><xs:enumeration value=\"PC1\"/><xs:enumeration value=\"PC2\"/><xs:enumeration value=\"PC3\"/><xs:enumeration value=\"PI1\"/><xs:enumeration value=\"PI2\"/><xs:enumeration value=\"PI3\"/><xs:enumeration value=\"PP1\"/><xs:enumeration value=\"PP2\"/><xs:enumeration value=\"PP3\"/><xs:enumeration value=\"PSS\"/><xs:enumeration value=\"PST\"/><xs:enumeration value=\"RES\"/><xs:enumeration value=\"SPE\"/><xs:enumeration value=\"THU\"/><xs:enumeration value=\"TON\"/><xs:enumeration value=\"WAR\"/><xs:enumeration value=\"WHP\"/><xs:enumeration value=\"ZZ1\"/><xs:enumeration value=\"ZZ2\"/><xs:enumeration value=\"ZZ3\"/><xs:enumeration value=\"ZZ4\"/><xs:enumeration value=\"ZZ5\"/><xs:enumeration value=\"ZZ6\"/><xs:enumeration value=\"ZZ7\"/><xs:enumeration value=\"ZZ8\"/><xs:enumeration value=\"ZZ9\"/></xs:restriction></xs:simpleType><xs:simpleType name=\"assetFileType\"><xs:annotation><xs:documentation>Code	Description	TIF		Tagged Image File	JPG		Joint Photographic Experts Group	EPS		Encapsulated PostScript	TXT		.txt TEXT FILE	FLV		.flv VIDEO FILE	F4V		.f4v VIDEO FILE	AVI		.avi VIDEO FILE	WEBM	.webm VIDEO FILE	OGV		.ogv VIDEO VILE	MP4		.mp4 VIDEO FILE	MKV		.mkv VIDEO FILE	AIF		.aif AUDIO FILE	WAV	.wav AUDIO FILE	WMA	.wma AUDIO FILE	OGG	.ogg AUDIO FILE	PCM		.pcm AUDIO FILE	AC3		.ac3 AUDIO FILE	MIDI		.mid AUDIO FILE	MP3		.mp3 AUDIO FILE	AAC		.aac AUDIO FILE	GIF		Graphics Interchange Format	BMP		Bitmap Image	PNG		Portable Network Graphics	PDF		Portable Document Format	DOC		MS Word	XLS		MS Excel</xs:documentation></xs:annotation><xs:restriction base=\"xs:string\"><xs:enumeration value=\"TIF\"/><xs:enumeration value=\"JPG\"/><xs:enumeration value=\"EPS\"/><xs:enumeration value=\"TXT\"/><xs:enumeration value=\"FLV\"/><xs:enumeration value=\"F4V\"/><xs:enumeration value=\"AVI\"/><xs:enumeration value=\"WEBM\"/><xs:enumeration value=\"OGV\"/><xs:enumeration value=\"MP4\"/><xs:enumeration value=\"MKV\"/><xs:enumeration value=\"AIF\"/><xs:enumeration value=\"WAV\"/><xs:enumeration value=\"WMA\"/><xs:enumeration value=\"OGG\"/><xs:enumeration value=\"PCM\"/><xs:enumeration value=\"AC3\"/><xs:enumeration value=\"MIDI\"/><xs:enumeration value=\"MP3\"/><xs:enumeration value=\"AAC\"/><xs:enumeration value=\"GIF\"/><xs:enumeration value=\"BMP\"/><xs:enumeration value=\"PNG\"/><xs:enumeration value=\"PDF\"/><xs:enumeration value=\"DOC\"/><xs:enumeration value=\"XLS\"/></xs:restriction></xs:simpleType><xs:simpleType name=\"resolutionType\"><xs:annotation><xs:documentation>Code	Description	72	96	300	600	800	1200</xs:documentation></xs:annotation><xs:restriction base=\"xs:string\"><xs:enumeration value=\"72\"/><xs:enumeration value=\"96\"/><xs:enumeration value=\"300\"/><xs:enumeration value=\"600\"/><xs:enumeration value=\"800\"/><xs:enumeration value=\"1200\"/></xs:restriction></xs:simpleType><xs:simpleType name=\"representationType\"><xs:annotation><xs:documentation>Code	Description	A	Actual	R	Representative</xs:documentation></xs:annotation><xs:restriction base=\"xs:string\"><xs:enumeration value=\"A\"/><xs:enumeration value=\"R\"/></xs:restriction></xs:simpleType><xs:simpleType name=\"colorModeType\"><xs:annotation><xs:documentation>Code	Description	RGB	RGB	CMY	CMYK	GRA	Gray Scale	OTH	Other	WEB	Vector B/W	VEC	Vector Color	BIT	Bitmap</xs:documentation></xs:annotation><xs:restriction base=\"xs:string\"><xs:enumeration value=\"RGB\"/><xs:enumeration value=\"CMY\"/><xs:enumeration value=\"GRA\"/><xs:enumeration value=\"OTH\"/><xs:enumeration value=\"WEB\"/><xs:enumeration value=\"VEC\"/><xs:enumeration value=\"BIT\"/></xs:restriction></xs:simpleType><xs:simpleType name=\"backgroundType\"><xs:annotation><xs:documentation>Code	Description	WHI	White	CLI	White w/clipping path	TRA	Transparent	OTH	Other	NUL	N/A</xs:documentation></xs:annotation><xs:restriction base=\"xs:string\"><xs:enumeration value=\"WHI\"/><xs:enumeration value=\"CLI\"/><xs:enumeration value=\"TRA\"/><xs:enumeration value=\"OTH\"/><xs:enumeration value=\"NUL\"/></xs:restriction></xs:simpleType><xs:simpleType name=\"orientationViewType\"><xs:annotation><xs:documentation>Code	Description	ANG	Angle	BAC	Back	BOT	Bottom	CON	Connector	FRO	Front	KIT	Kit	LEF	Left	LIF	Lifestyle	NUL	Not Applicable	OTH	Other	RIT	Right	SID	Side	TOP	Top	ZZ1	User 1	ZZ2	User 2	ZZ3	User 3	ZZ4	User 4	ZZ5	User 5	ZZ6	User 6	ZZ7	User 7	ZZ8	User 8	ZZ9	User 9</xs:documentation></xs:annotation><xs:restriction base=\"xs:string\"><xs:enumeration value=\"ANG\"/><xs:enumeration value=\"BAC\"/><xs:enumeration value=\"BOT\"/><xs:enumeration value=\"CON\"/><xs:enumeration value=\"FRO\"/><xs:enumeration value=\"KIT\"/><xs:enumeration value=\"LEF\"/><xs:enumeration value=\"LIF\"/><xs:enumeration value=\"NUL\"/><xs:enumeration value=\"RIT\"/><xs:enumeration value=\"SID\"/><xs:enumeration value=\"TOP\"/><xs:enumeration value=\"ZZ1\"/><xs:enumeration value=\"ZZ2\"/><xs:enumeration value=\"ZZ3\"/><xs:enumeration value=\"ZZ4\"/><xs:enumeration value=\"ZZ5\"/><xs:enumeration value=\"ZZ6\"/><xs:enumeration value=\"ZZ7\"/><xs:enumeration value=\"ZZ8\"/><xs:enumeration value=\"ZZ9\"/></xs:restriction></xs:simpleType><xs:simpleType name=\"dimensionUOMType\"><xs:annotation><xs:documentation>Code	Description	PX	Pixels	IN	Inches	CM	Centimeters</xs:documentation></xs:annotation><xs:restriction base=\"xs:string\"><xs:enumeration value=\"PX\"/><xs:enumeration value=\"IN\"/><xs:enumeration value=\"CM\"/></xs:restriction></xs:simpleType><!-- \"Footer\" element definition --><xs:element name=\"Footer\"><xs:complexType><xs:sequence><xs:element name=\"RecordCount\" type=\"xs:string\"/></xs:sequence></xs:complexType></xs:element></xs:schema>");
        }


        public void clear()
        {
            analysisComplete = false;
            analysisWarnings = 0;
            analysisErrors = 0;
            appsCount = 0;
            filePath = "";
            version = "";
            Company = "";
            SenderName = "";
            SenderPhone = "";
            TransferDate = "";
            BrandAAIAID = "";
            DocumentTitle = "";
            EffectiveDate = "";
            SubmissionType = "";
            VcdbVersionDate = "";
            QdbVersionDate = "";
            PcdbVersionDate = "";
            distinctParts.Clear();
            distinctPartTypes.Clear();
            distinctMfrLabels.Clear();
            distinctAssets.Clear();
            distinctBasevids.Clear();
            partsAppsCounts.Clear();
            partsPartTypes.Clear();
            partsPositions.Clear();
            parttypeDisagreementErrors.Clear();
            duplicateErrors.Clear();
            overlapsErrors.Clear();
            CNCoverlapsErrors.Clear();
            basevehicleidsErrors.Clear();
            vcdbCodesErrors.Clear();
            vcdbConfigurationsErrors.Clear();
            parttypePositionErrors.Clear();
            xmlValidationErrors.Clear();
        }


        public void clearAnalysisResults()
        {
            analysisComplete = false;
            analysisWarnings = 0;
            analysisErrors = 0;
            duplicateErrors.Clear();
            overlapsErrors.Clear();
            CNCoverlapsErrors.Clear();
            basevehicleidsErrors.Clear();
            vcdbCodesErrors.Clear();
            vcdbConfigurationsErrors.Clear();
            parttypePositionErrors.Clear();
            xmlValidationErrors.Clear();
        }

                
        public List<string> duplicates(VCdb vcdb, PCdb pcdb, IProgress<int> progress)
        {
            // hashtable for temp storage of [basevid_parttype_position_qualifiers_mfrlable]="appId1,appId2,AppId3..."
            // any element that has more than one appId in the second dimension, is a vehicle with duplicates.
            Dictionary<String, String> duplicatesHashtable = new Dictionary<string, string>();
            int i; int percentProgress = 0; string hashkey = ""; int appidTemp = 0;

            for (i = 0; i <= appsCount - 1; i++)
            {
                //build a hashkey that defines a vehicle. use Tabs characters to delimit the hashstring so it can be parsed apart later for presenation
                hashkey = apps[i].basevehilceid.ToString() + "\t" + apps[i].parttypeid.ToString() + "\t" + apps[i].positionid.ToString() + "\t" + apps[i].namevalpairString(true) + "\t" + apps[i].mfrlabel + "\t" + apps[i].part;
                if (duplicatesHashtable.ContainsKey(hashkey))
                {
                    duplicatesHashtable[hashkey] += "," + apps[i].id.ToString();
                }
                else
                {
                    duplicatesHashtable.Add(hashkey, apps[i].id.ToString());
                }

                if (progress != null)
                {// only report progress on whole percentage steps (100 total reports). reporting on every iteration is too process intensive
                    percentProgress = Convert.ToInt32(((double)i / (double)appsCount) * 100);
                    if ((double)percentProgress % (double)1 == 0) { progress.Report(percentProgress); }
                }
            }

            foreach (KeyValuePair<string, string> entry in duplicatesHashtable)
            {
                if (entry.Value.Contains(","))
                {
                    string[] appidStringsArray = entry.Value.Split(',');
                    appidTemp = Convert.ToInt32(appidStringsArray[0]);
                    duplicateErrors.Add(apps[appidTemp].basevehilceid.ToString() + "\t" + vcdb.niceMakeOfBasevid(apps[appidTemp].basevehilceid) + "\t" + vcdb.niceModelOfBasevid(apps[appidTemp].basevehilceid) + "\t" + vcdb.niceYearOfBasevid(apps[appidTemp].basevehilceid) + "\t" + pcdb.niceParttype(apps[appidTemp].parttypeid) + "\t" + pcdb.nicePosition(apps[appidTemp].positionid) + "\t" + apps[appidTemp].niceAttributesString(vcdb,true) + "\t" + entry.Value);
                    analysisWarnings++;
                }
            }
            return duplicateErrors;
        }



        /*
        public List<string> duplicates(VCdb vcdb, PCdb pcdb, IProgress<int> progress)
        {
            int i; int percentProgress = 0;
            BaseVehicle basevidTemp = new BaseVehicle();
            for (i = 0; i <= appsCount - 2; i++)
            {
                if (apps[i].basevehilceid == apps[i + 1].basevehilceid && apps[i].part == apps[i + 1].part && apps[i].parttypeid == apps[i + 1].parttypeid && apps[i].positionid == apps[i + 1].positionid && apps[i].mfrlabel == apps[i + 1].mfrlabel && apps[i].asset == apps[i + 1].asset && apps[i].assetitemorder == apps[i + 1].assetitemorder && apps[i].namevalpairString(true) == apps[i + 1].namevalpairString(true))
                {
                    duplicateErrors.Add(apps[i].id + "\t" + vcdb.niceMakeOfBasevid(apps[i].basevehilceid) + "\t" + vcdb.niceModelOfBasevid(apps[i].basevehilceid) + "\t" + vcdb.niceYearOfBasevid(apps[i].basevehilceid).ToString() + "\t" + pcdb.niceParttype(apps[i].parttypeid) + "\t" + pcdb.nicePosition(apps[i].positionid) + "\t" + apps[i].quantity + "\t" + apps[i].part + "\t" + apps[i].namevalpairString(true));
                    duplicateErrors.Add(apps[i + 1].id + "\t" + vcdb.niceMakeOfBasevid(apps[i + 1].basevehilceid) + "\t" + vcdb.niceModelOfBasevid(apps[i + 1].basevehilceid) + "\t" + vcdb.niceYearOfBasevid(apps[i + 1].basevehilceid).ToString() + "\t" + pcdb.niceParttype(apps[i + 1].parttypeid) + "\t" + pcdb.nicePosition(apps[i + 1].positionid) + "\t" + apps[i + 1].quantity + "\t" + apps[i + 1].part + "\t" + apps[i + 1].namevalpairString(true));
                    analysisWarnings++;
                }

                if (progress != null)
                {// only report progress on whole percentage steps (100 total reports). reporting on every iteration is too process intensive
                    percentProgress = Convert.ToInt32(((double)i / (double)appsCount) * 100);
                    if ((double)percentProgress % (double)1 == 0) { progress.Report(percentProgress); }
                }
            }
            return duplicateErrors;
        }

        */


        public List<string> overlaps(VCdb vcdb, PCdb pcdb, IProgress<int> progress)
        {
            // hashtable for temp storage of [basevid_parttype_position_qualifiers_mfrlable]="partA,partB,partC..."
            // any element that has more than one part in the second dimension, is a vehicle with overlaps.
            Dictionary<string, List<string>> overlapsHashtable = new Dictionary<string, List<String>>();
            List<String> partsListtemp;
            int basevidTemp = 0;
            string partsString = "";
            VCdbAttribute myVCdbAttribute = new VCdbAttribute(); string niceAttributesString="";

            int i; int percentProgress = 0; string hashkey = ""; 

            for (i = 0; i <= appsCount - 1; i++)
            {
                //build a hashkey that defines a vehicle. use Tabs characters to delimit the hashstring so it can be parsed apart later for presenation
                hashkey = apps[i].basevehilceid.ToString() + "\t" + apps[i].parttypeid.ToString()+ "\t" + apps[i].positionid + "\t" + apps[i].namevalpairString(false) + "\t" + apps[i].notes + "\t" + apps[i].mfrlabel;
                if (overlapsHashtable.ContainsKey(hashkey))
                {
                    if(!overlapsHashtable[hashkey].Contains(apps[i].part))
                    {
                        overlapsHashtable[hashkey].Add(apps[i].part);
                    }
                }
                else
                {
                    overlapsHashtable.Add(hashkey, partsListtemp = new List<string>());
                    overlapsHashtable[hashkey].Add(apps[i].part);
                }

                if (progress != null)
                {// only report progress on whole percentage steps (100 total reports). reporting on every iteration is too process intensive
                    percentProgress = Convert.ToInt32(((double)i / (double)appsCount) * 100);
                    if ((double)percentProgress % (double)1 == 0) { progress.Report(percentProgress); }
                }
            }

            foreach (KeyValuePair<string, List<string>> entry in overlapsHashtable)
            {
                if(entry.Value.Count>1)
                {
                    string[] fields = entry.Key.Split('\t');
                    basevidTemp=Convert.ToInt32(fields[0]);
                    partsString = String.Join(", ", entry.Value);
                    niceAttributesString = "";

                    if (fields[3].Trim() != "")
                    {
                        string[] attributes = fields[3].Split(';');
                        foreach (string attribute in attributes) { string[] attributePieces = attribute.Split(':'); myVCdbAttribute.name = attributePieces[0]; myVCdbAttribute.value = Convert.ToInt32(attributePieces[1]); niceAttributesString += vcdb.niceAttribute(myVCdbAttribute) + "; "; }
                    }

                    if (fields[4].Trim() != "") { niceAttributesString += " " + fields[4].Trim(); }
                    niceAttributesString = niceAttributesString.Trim();
                    if (niceAttributesString != "" && niceAttributesString.Substring(niceAttributesString.Length - 1, 1) == ";") { niceAttributesString = niceAttributesString.Substring(0, niceAttributesString.Length - 1); }
                    overlapsErrors.Add(basevidTemp.ToString() + "\t" + vcdb.niceMakeOfBasevid(basevidTemp) + "\t" + vcdb.niceModelOfBasevid(basevidTemp) + "\t" + vcdb.niceYearOfBasevid(basevidTemp) + "\t" + pcdb.niceParttype(Convert.ToInt32(fields[1])) + "\t" + pcdb.nicePosition(Convert.ToInt32(fields[2])) + "\t" + niceAttributesString + "\t" + partsString);
                    analysisErrors++;
                }
            }
            return overlapsErrors;
        }


        public List<string> CNCoverlaps(VCdb vcdb, PCdb pcdb, IProgress<int> progress)
        {
            int i; int percentProgress = 0; int groupnumber = 1;
            for (i = 0; i <= appsCount - 2; i++)
            {
                if (apps[i].basevehilceid == apps[i + 1].basevehilceid &&
                    apps[i].parttypeid == apps[i + 1].parttypeid &&
                    apps[i].positionid == apps[i + 1].positionid &&
                    apps[i].mfrlabel == apps[i + 1].mfrlabel &&
                    apps[i].asset == apps[i + 1].asset &&
                    apps[i].assetitemorder == apps[i + 1].assetitemorder &&
                    ((apps[i].namevalpairString(true) == "" && apps[i + 1].namevalpairString(true) != "") || (apps[i].namevalpairString(true) != "" && apps[i + 1].namevalpairString(true) == "")))
                {
                    CNCoverlapsErrors.Add(groupnumber.ToString() + "\t" + apps[i].id.ToString() + "\t" + apps[i].basevehilceid.ToString() + "\t" + vcdb.niceMakeOfBasevid(apps[i].basevehilceid) + "\t" + vcdb.niceModelOfBasevid(apps[i].basevehilceid) + "\t" + vcdb.niceYearOfBasevid(apps[i].basevehilceid).ToString() + "\t" + pcdb.niceParttype(apps[i].parttypeid) + "\t" + pcdb.nicePosition(apps[i].positionid) + "\t" + apps[i].quantity.ToString() + "\t" + apps[i].part + "\t" + apps[i].niceAttributesString(vcdb,true));
                    CNCoverlapsErrors.Add(groupnumber.ToString() + "\t" + apps[i + 1].id.ToString() + "\t" + apps[i+1].basevehilceid.ToString() + "\t" + vcdb.niceMakeOfBasevid(apps[i].basevehilceid) + "\t" + vcdb.niceModelOfBasevid(apps[i].basevehilceid) + "\t" + vcdb.niceYearOfBasevid(apps[i].basevehilceid).ToString() + "\t" + pcdb.niceParttype(apps[i + 1].parttypeid) + "\t" + pcdb.nicePosition(apps[i + 1].positionid) + "\t" + apps[i + 1].quantity.ToString() + "\t" + apps[i + 1].part + "\t" + apps[i+1].niceAttributesString(vcdb, true));
                    analysisErrors++; groupnumber++;
                }
                if (progress != null)
                {// only report progress on whole percentage steps (100 total reports). reporting on every iteration is too process intensive
                    percentProgress = Convert.ToInt32(((double)i / (double)appsCount) * 100);
                    if ((double)percentProgress % (double)1 == 0) { progress.Report(percentProgress); }
                }
            }
            return CNCoverlapsErrors;
        }

        public List<string> invalidBasevids(VCdb vcdb, PCdb pcdb, IProgress<int> progress)
        {
            int i; int percentProgress = 0;
            BaseVehicle basevidTemp = new BaseVehicle();
            for (i = 0; i <= appsCount - 1; i++)
            {
                if (!vcdb.basevid.TryGetValue(apps[i].basevehilceid, out basevidTemp))
                {
                    basevehicleidsErrors.Add(apps[i].id + "\t" + apps[i].basevehilceid.ToString() + "\t" + pcdb.niceParttype(apps[i].parttypeid) + "\t" + pcdb.nicePosition(apps[i].positionid) + "\t" + apps[i].quantity + "\t" + apps[i].part + "\t" + apps[i].niceAttributesString(vcdb, true));
                    analysisErrors++;
                }

                if (progress != null)
                {// only report progress on whole percentage steps (100 total reports). reporting on every iteration is too process intensive
                    percentProgress = Convert.ToInt32(((double)i / (double)appsCount) * 100);
                    if ((double)percentProgress % (double)1 == 0) { progress.Report(percentProgress); }
                }
            }
            return basevehicleidsErrors;
        }

        public List<string> invalidAttributes(VCdb vcdb, PCdb pcdb, IProgress<int> progress)
        {
            int i; string errorsString = ""; int percentProgress = 0;
            BaseVehicle basevidTemp = new BaseVehicle();
            for (i = 0; i <= appsCount - 1; i++)
            {
                if (apps[i].VCdbAttributes.Count > 0)
                {
                    errorsString = "";
                    foreach (VCdbAttribute myAttribute in apps[i].VCdbAttributes)
                    {
                        if (!vcdb.validAttribute(myAttribute))
                        {
                            errorsString += myAttribute.name + ":" + myAttribute.value.ToString() + ";";
                        }
                    }

                    if (errorsString != "")
                    {
                        vcdbCodesErrors.Add(apps[i].id + "\t" + vcdb.niceMakeOfBasevid(apps[i].basevehilceid) + "\t" + vcdb.niceModelOfBasevid(apps[i].basevehilceid) + "\t" + vcdb.niceYearOfBasevid(apps[i].basevehilceid) + "\t" + pcdb.niceParttype(apps[i].parttypeid) + "\t" + pcdb.nicePosition(apps[i].positionid) + "\t" + apps[i].quantity + "\t" + apps[i].part + "\t" + apps[i].niceAttributesString(vcdb, false) + "\t" + apps[i].notes);
                        analysisErrors++;
                    }
                }
                if (progress != null)
                {// only report progress on whole percentage steps (100 total reports). reporting on every iteration is too process intensive
                    percentProgress = Convert.ToInt32(((double)i / (double)appsCount) * 100);
                    if ((double)percentProgress % (double)1 == 0) { progress.Report(percentProgress); }
                }
            }
            return vcdbCodesErrors;
        }





        public List<string> invalidConfigs(VCdb vcdb, PCdb pcdb, IProgress<int> progress)
        {
            int i; int j; int percentProgress = 0;
            BaseVehicle basevidTemp = new BaseVehicle();
            bool appHasInvalidAttribute;
            App tempApp = new App();
            List<VCdbAttribute> tempAttributesList = new List<VCdbAttribute>();

            for (i = 0; i <= appsCount - 1; i++)
            {
                if (apps[i].VCdbAttributes.Count > 0)
                {
                    appHasInvalidAttribute = false; foreach (VCdbAttribute myAttribute in apps[i].VCdbAttributes) { if (!vcdb.validAttribute(myAttribute)) { appHasInvalidAttribute = true; } }
                    if (!appHasInvalidAttribute)
                    {// dont include invalid attributed apps in vcdb config analysis - these are handled in the "invalid attributes" analysis

                        tempApp = apps[i];
                        if(!vcdb.configIsValid(tempApp))
                        {
                            // this apps's combination of attribute values is not found in the specified VCdb.
                            // create a new list of attributes for this app the have excluded and attribute the has U/K as an option
                            tempAttributesList.Clear();
                            for (j=0; j<= tempApp.VCdbAttributes.Count-1; j++)
                            {
                                if(!vcdb.attributeHasUKasOption(tempApp.basevehilceid,tempApp.VCdbAttributes[j].name))
                                {
                                    tempAttributesList.Add(tempApp.VCdbAttributes[j]);
                                }
                            }

                            tempApp.VCdbAttributes = tempAttributesList;
                            if (!vcdb.configIsValid(tempApp))
                            {
                                vcdbConfigurationsErrors.Add(apps[i].id + "\t" + vcdb.niceMakeOfBasevid(apps[i].basevehilceid) + "\t" + vcdb.niceModelOfBasevid(apps[i].basevehilceid) + "\t" + vcdb.niceYearOfBasevid(apps[i].basevehilceid) + "\t" + pcdb.niceParttype(apps[i].parttypeid) + "\t" + pcdb.nicePosition(apps[i].positionid) + "\t" + apps[i].quantity + "\t" + apps[i].part + "\t" + apps[i].niceAttributesString(vcdb, false) + "\t" + apps[i].notes);
                                analysisErrors++;
                            }
                        }
                    }
                }

                if (progress != null)
                {// only report progress on whole percentage steps (100 total reports). reporting on every iteration is too process intensive
                    percentProgress = Convert.ToInt32(((double)i / (double)appsCount) * 100);
                    if ((double)percentProgress % (double)1 == 0) { progress.Report(percentProgress); }
                }
            }
            return vcdbConfigurationsErrors;
        }


        public List<string> invalidParttypePositions(VCdb vcdb, PCdb pcdb, IProgress<int> progress)
        {
            int i; int percentProgress = 0;
            BaseVehicle basevidTemp = new BaseVehicle();

            for (i = 0; i <= appsCount - 1; i++)
            {

                if (!pcdb.codmasterParttypePoisitions.Contains(apps[i].parttypeid.ToString() + "_" + apps[i].positionid.ToString()))
                {
                    parttypePositionErrors.Add(apps[i].id + "\t" + vcdb.niceMakeOfBasevid(apps[i].basevehilceid) + "\t" + vcdb.niceModelOfBasevid(apps[i].basevehilceid) + "\t" + vcdb.niceYearOfBasevid(apps[i].basevehilceid) + "\t" + pcdb.niceParttype(apps[i].parttypeid) + "\t" + pcdb.nicePosition(apps[i].positionid) + "\t" + apps[i].quantity + "\t" + apps[i].part + "\t" + apps[i].niceAttributesString(vcdb, true));
                    analysisErrors++;
                }

                /* this is how you would query the pcdb directly on every app - VERY SLOW!
                sqlString = "select codemasterid from codemaster where partterminologyid = " + apps[i].parttypeid.ToString() + " and positionid = " + apps[i].positionid.ToString();
                try
                {
                    OleDbCommand command = new OleDbCommand(sqlString, pcdb.pcdbConnection);
                    OleDbDataReader reader = command.ExecuteReader();
                    if (!reader.Read())
                    {
                        parttypePositionErrors.Add(apps[i].id + "\t" + vcdb.niceMakeOfBasevid(apps[i].basevehilceid) + "\t" + vcdb.niceModelOfBasevid(apps[i].basevehilceid) + "\t" + vcdb.niceYearOfBasevid(apps[i].basevehilceid) + "\t" + pcdb.niceParttype(apps[i].parttypeid) + "\t" + pcdb.nicePosition(apps[i].positionid) + "\t" + apps[i].quantity + "\t" + apps[i].part + "\t" + apps[i].niceAttributesString(vcdb, false) + "\t" + apps[i].notes);
                        analysisErrors++;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(sqlString);
                }
            
    */

                if (progress != null)
                {// only report progress on whole percentage steps (100 total reports). reporting on every iteration is too process intensive
                    percentProgress = Convert.ToInt32(((double)i / (double)appsCount) * 100);
                    if ((double)percentProgress % (double)1 == 0) { progress.Report(percentProgress); }
                }
            }
            return parttypePositionErrors;
        }


        public List<string> disperateAttributes(VCdb vcdb, PCdb pcdb, IProgress<int> progress)
        {
            // find vehicles (basevid/parttype/position/mfrlabel) that contain apples-to-oranges qualifier pairings
            // for example 2015 Cherokee takes two different brake pads: PadsA fit "Rear Disc", PadsB fit "V6 3.2L Engine"   
            // counterman: "does your Cherokee have the V6 engine or does it have Rear Disc brakes?" WTF
            // The algorithm here is to verify that any attributes (just the names, not the id values) in use are in use across the whole vehilce (within a distinct basevid/parttype/position/mfrlabel)
            // this concept was suggested by Courtney Pedler of Autology Data


            int i; int percentProgress = 0;
            BaseVehicle basevidTemp = new BaseVehicle();
            string vehiclesKey = "";
            bool found = false;
            List<VCdbAttribute> VCdbAttributesTemp;
            List<string> vcdbAttributeNamesFullVehicle = new List<string>();
            List<string> vcdbAttributeNamesThisApp = new List<string>();
            Dictionary<string, List<int>> vehiclesAppidLists = new Dictionary<string, List<int>>();
            List<int> appsListtemp;

            for (i = 0; i <= appsCount - 1; i++)
            {
                vehiclesKey = apps[i].basevehilceid.ToString() + "_" + apps[i].parttypeid.ToString() + "_" + apps[i].positionid.ToString() + "_" + apps[i].mfrlabel;
                if(!vehiclesAppidLists.ContainsKey(vehiclesKey))
                {// establish a new basevid/parttype/position/mfrlabel dictionary entry with this app's element number in the list
                    vehiclesAppidLists.Add(vehiclesKey, appsListtemp = new List<int>());
                }
                vehiclesAppidLists[vehiclesKey].Add(i);// add the "apps" array element index to the list of apps that have this vehicle (basevid/parttype/position/mfrlabel)
            }

            for (i = 0; i <= vehiclesAppidLists.Count - 1; i++)
            {
                if (vehiclesAppidLists.ElementAt(i).Value.Count > 1)
                {   // this vehicle (basevid/parttype/position/mfrlabel) has multiple applied parts
                    // see if any of the apps contain vcdb-coded attributes

                    vcdbAttributeNamesFullVehicle.Clear();
                    foreach (int appid in vehiclesAppidLists.ElementAt(i).Value)
                    {
                        if (apps[appid].VCdbAttributes.Count > 0)
                        {
                            foreach (VCdbAttribute attributeTemp in apps[appid].VCdbAttributes)
                            {
                                if (!vcdbAttributeNamesFullVehicle.Contains(attributeTemp.name))
                                {
                                    vcdbAttributeNamesFullVehicle.Add(attributeTemp.name);
                                }
                            }
                        }
                    }

                    if (vcdbAttributeNamesFullVehicle.Count > 0)
                    {
                        // vcdbAttributeNamesFullVehicle now contains a distinct list of attributes used against this vehicle (basevid/parttype/position/mfrlabel)
                        // re-check all apps in list to verify that all have every distinct attribute in use (regardless of the attribute values)
                        foreach (int appid in vehiclesAppidLists.ElementAt(i).Value)
                        {
                            vcdbAttributeNamesThisApp.Clear();
                            foreach (VCdbAttribute attributeTemp in apps[appid].VCdbAttributes)
                            {
                                vcdbAttributeNamesThisApp.Add(attributeTemp.name);
                            }

                            foreach(string vcdbAttributeName in vcdbAttributeNamesFullVehicle)
                            {
                                if(!vcdbAttributeNamesThisApp.Contains(vcdbAttributeName))
                                {
                                    disperateAttributeErrors.Add(vcdb.niceMakeOfBasevid(apps[appid].basevehilceid)+"\t"+ vcdb.niceModelOfBasevid(apps[appid].basevehilceid)+"\t"+ vcdb.niceYearOfBasevid(apps[appid].basevehilceid)+"\t"+pcdb.niceParttype(apps[appid].parttypeid)+"\t"+pcdb.nicePosition(apps[appid].positionid)+"\t"+apps[appid].part+"\t"+apps[appid].niceAttributesString(vcdb,true));
                                }
                            }





                        }



                    }




                }
            }




                return disperateAttributeErrors;

        }


        public int import(string _filePath, string _schemaString, IProgress<int> progress)
        {
            // if schema string is "", select XSD according to what ACES version is claimed by the XML

            filePath = _filePath;
            xmlValidationErrors.Clear();
            successfulImport = false;
            XDocument xmlDoc = null;
            XmlSchemaSet schemas = new XmlSchemaSet();
            string schemaString = "";
            bool found;

            if (_schemaString == "")
            {// no schema string was passed in - extract ACES version from XML
                try
                {
                    xmlDoc = XDocument.Load(filePath);
                    version = (string)xmlDoc.Element("ACES").Attribute("version");
                    if(ACESschemas.TryGetValue(version, out schemaString))
                    {// ACES version claimed by XML file was found in the dictionary of schemas

                        schemas.Add("", XmlReader.Create(new StringReader(schemaString)));
                    }
                    else
                    {// ACES version claimed by XML file was NOT found in the dictionary of schemas
                        xmlValidationErrors.Add("Your XML file contains an unsupported version (" + version + ") of ACES");
                        return 0;
                    }
                }
                catch (Exception ex)
                {
                    xmlValidationErrors.Add(ex.Message);
                    return 0;
                }
            }
            else
            {
                schemas.Add("", XmlReader.Create(new StringReader(_schemaString)));
            }


            try
            {
                xmlDoc = null;
                xmlDoc = XDocument.Load(filePath);
                xmlDoc.Validate(schemas, (o, e) => { xmlValidationErrors.Add(e.Message); });

                VcdbVersionDate = (string)xmlDoc.Element("ACES").Element("Header").Element("VcdbVersionDate");
                PcdbVersionDate = (string)xmlDoc.Element("ACES").Element("Header").Element("PcdbVersionDate");
                QdbVersionDate = (string)xmlDoc.Element("ACES").Element("Header").Element("QdbVersionDate");
                DocumentTitle = (string)xmlDoc.Element("ACES").Element("Header").Element("DocumentTitle");
                version = (string)xmlDoc.Element("ACES").Attribute("version");

                // get an app count so we can allocate memory space 
                int percentProgress = 0;
                int totalApps = xmlDoc.Descendants("App").Count();
                apps = new App[totalApps]; // allocate i number of instances of App class in "apps" array
                appsCount = 0;

                foreach (XElement appElement in xmlDoc.Descendants("App"))
                {
                    apps[appsCount] = new App();
                    apps[appsCount].id = Convert.ToInt32(appElement.Attribute("id").Value);
                    apps[appsCount].basevehilceid = Convert.ToInt32(appElement.Element("BaseVehicle").Attribute("id").Value);
                    if (!distinctBasevids.Contains(apps[appsCount].basevehilceid)) { distinctBasevids.Add(apps[appsCount].basevehilceid); }
                    if ((string)appElement.Element("Position") != null){apps[appsCount].positionid = Convert.ToInt32(appElement.Element("Position").Attribute("id").Value);}
                    apps[appsCount].parttypeid = Convert.ToInt32(appElement.Element("PartType").Attribute("id").Value);
                    apps[appsCount].mfrlabel = (string)appElement.Element("MfrLabel");
                    apps[appsCount].quantity = Convert.ToInt32((string)appElement.Element("Qty"));
                    apps[appsCount].part = (string)appElement.Element("Part");


                    if(apps[appsCount].mfrlabel !=null &&  !distinctMfrLabels.Contains(apps[appsCount].mfrlabel)){distinctMfrLabels.Add(apps[appsCount].mfrlabel);}
                    if (!distinctPartTypes.Contains(apps[appsCount].parttypeid)) {distinctPartTypes.Add(apps[appsCount].parttypeid);}

                    if (!distinctParts.Contains(apps[appsCount].part))
                    {
                        distinctParts.Add(apps[appsCount].part); partsAppsCounts.Add(apps[appsCount].part, 1);
                    }
                    else
                    {// this part has been seen before - increment the associated count

                        partsAppsCounts[apps[appsCount].part] += 1;
                    }

                    // add this app's part/parttype combination to the partsPartTypes hashtable
                    if (partsPartTypes.ContainsKey(apps[appsCount].part))
                    {
                        // check for the existance of this parttypeid in the comma-seperated list before adding it.
                        found = false;
                        string[] chunks = partsPartTypes[apps[appsCount].part].Split('\t');
                        foreach(string chunk in chunks)
                        {
                            if(Convert.ToInt32(chunk) == Convert.ToInt32(apps[appsCount].parttypeid.ToString())){found = true; break;}
                        }
                        if (!found) { partsPartTypes[apps[appsCount].part] += "\t" + apps[appsCount].parttypeid.ToString(); }

                    }
                    else
                    {
                        partsPartTypes.Add(apps[appsCount].part, apps[appsCount].parttypeid.ToString());
                    }


                    // add this app's part/position combination to the partsPositions hashtable
                    if (partsPositions.ContainsKey(apps[appsCount].part))
                    {
                        // check for the existance of this positonid in the comma-seperated list before adding it.
                        found = false;
                        string[] chunks = partsPositions[apps[appsCount].part].Split('\t');
                        foreach (string chunk in chunks)
                        {
                            if (Convert.ToInt32(chunk) == Convert.ToInt32(apps[appsCount].positionid.ToString())) { found = true; break; }
                        }
                        if (!found) { partsPositions[apps[appsCount].part] += "\t" + apps[appsCount].positionid.ToString(); }

                    }
                    else
                    {
                        partsPositions.Add(apps[appsCount].part, apps[appsCount].positionid.ToString());
                    }




                    apps[appsCount].asset = (string)appElement.Element("Asset");
                    if (!distinctAssets.Contains(apps[appsCount].asset)) { distinctAssets.Add(apps[appsCount].asset); }

                    foreach (XElement noteElement in appElement.Descendants("Note"))
                    {
                        apps[appsCount].notes += (string)noteElement +"; ";
                    }

                    string[] VCdbAttributeNames = new string[] { "Aspiration", "BedLength", "BedType", "BodyNumDoors", "BodyType", "BrakeABS", "BrakeSystem", "CylinderHeadType", "DriveType", "EngineBase", "EngineDesignation", "EngineMfr", "EngineVIN", "EngineVersion", "FrontBrakeType", "FrontSpringType", "FuelDeliverySubType", "FuelDeliveryType", "FuelSystemControlType", "FuelSystemDesign", "FuelType", "IgnitionSystemType", "MfrBodyCode", "PowerOutput", "RearBrakeType", "RearSpringType", "Region", "SteeringSystem", "SteeringType", "SubModel", "TransElecControlled", "TransmissionBase", "TransmissionControlType", "TransmissionMfr", "TransmissionMfrCode", "TransmissionNumSpeeds", "TransmissionType", "ValvesPerEngine", "VehicleType", "WheelBase" };

                    foreach (string VCdbAttributeName in VCdbAttributeNames)
                    {// roll through the entire of list of possible VCdb attribute names looking for nodes like <SubModel id="13">
                        if (appElement.Element(VCdbAttributeName) != null)
                        {
                            VCdbAttribute VCdbAttributeTemp = new VCdbAttribute();
                            VCdbAttributeTemp.name = VCdbAttributeName;
                            VCdbAttributeTemp.value = Convert.ToInt32(appElement.Element(VCdbAttributeName).Attribute("id").Value);
                            apps[appsCount].VCdbAttributes.Add(VCdbAttributeTemp);
                        }
                    }
                    appsCount++;
                    if (progress != null)
                    {// only report progress on whole percentage steps (100 total reports). reporting on every iteration is too process intensive
                        percentProgress = Convert.ToInt32(((double)appsCount / (double)totalApps) * 100);
                        if ((double)percentProgress % (double)1 == 0) { progress.Report(percentProgress); }
                    }
                }
                Array.Sort(apps); // sort apps by basevehilceid/parttypeid/positionid/part/mfrlabel/qualifiers&notes/asset/assetorder. Sorting the apps this way will allow row-by-row comparison when checking for duplicates, overlaps and CNC overlaps.
                distinctParts.Sort();

            }
            catch (Exception ex)
            {
                xmlValidationErrors.Add(ex.Message);
            }

            if(xmlValidationErrors.Count==0 && appsCount > 0){ successfulImport = true; }
            return appsCount;
        }



        public string generateAssessmentFile(string _filePath,PCdb pcdb)
        {
            string partTypeNameListString = ""; string positionNameListString = "";

            string codeVersion= System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string excelTabColorXMLtag = "";
            try
            {
                using (StreamWriter sw = new StreamWriter(_filePath))
                {
                    sw.Write("<?xml version=\"1.0\"?><?mso-application progid=\"Excel.Sheet\"?><Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\" xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\" xmlns:html=\"http://www.w3.org/TR/REC-html40\"><DocumentProperties xmlns=\"urn:schemas-microsoft-com:office:office\"><Author>ACESinspector</Author><LastAuthor>ACESinspector</LastAuthor><Created>2017-02-20T01:10:23Z</Created><LastSaved>2017-02-20T02:49:36Z</LastSaved><Version>14.00</Version></DocumentProperties><OfficeDocumentSettings xmlns=\"urn:schemas-microsoft-com:office:office\"><AllowPNG/></OfficeDocumentSettings><ExcelWorkbook xmlns=\"urn:schemas-microsoft-com:office:excel\"><WindowHeight>7500</WindowHeight><WindowWidth>15315</WindowWidth><WindowTopX>120</WindowTopX><WindowTopY>150</WindowTopY><TabRatio>785</TabRatio><ProtectStructure>False</ProtectStructure><ProtectWindows>False</ProtectWindows></ExcelWorkbook><Styles><Style ss:ID=\"Default\" ss:Name=\"Normal\"><Alignment ss:Vertical=\"Bottom\"/><Borders/><Font ss:FontName=\"Calibri\" x:Family=\"Swiss\" ss:Size=\"11\" ss:Color=\"#000000\"/><Interior/><NumberFormat/><Protection/></Style><Style ss:ID=\"s62\"><NumberFormat ss:Format=\"Short Date\"/></Style><Style ss:ID=\"s64\" ss:Name=\"Hyperlink\"><Font ss:FontName=\"Calibri\" x:Family=\"Swiss\" ss:Size=\"11\" ss:Color=\"#0000FF\" ss:Underline=\"Single\"/></Style><Style ss:ID=\"s65\"><Font ss:FontName=\"Calibri\" x:Family=\"Swiss\" ss:Size=\"11\" ss:Color=\"#000000\" ss:Bold=\"1\"/><Interior ss:Color=\"#D9D9D9\" ss:Pattern=\"Solid\"/></Style></Styles><Worksheet ss:Name=\"Stats\"><Table ss:ExpandedColumnCount=\"2\" x:FullColumns=\"1\" x:FullRows=\"1\" ss:DefaultRowHeight=\"15\"><Column ss:Width=\"116.25\"/><Column ss:Width=\"225\"/>");
                    sw.Write("<Row><Cell><Data ss:Type=\"String\">Input Filename</Data></Cell><Cell><Data ss:Type=\"String\">" + Path.GetFileName(filePath) + "</Data></Cell></Row>");
                    sw.Write("<Row><Cell><Data ss:Type=\"String\">Title</Data></Cell><Cell><Data ss:Type=\"String\">" + DocumentTitle + "</Data></Cell></Row>");
                    sw.Write("<Row><Cell><Data ss:Type=\"String\">VcdbVersionDate</Data></Cell><Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">" + version + "</Data></Cell></Row>");
                    sw.Write("<Row><Cell><Data ss:Type=\"String\">Application count</Data></Cell><Cell><Data ss:Type=\"Number\">"+appsCount.ToString()+"</Data></Cell></Row><Row>");
                    sw.Write("<Cell><Data ss:Type=\"String\">Unique Part count</Data></Cell><Cell><Data ss:Type=\"Number\">"+distinctParts.Count.ToString()+"</Data></Cell></Row>");
                    sw.Write("<Row><Cell><Data ss:Type=\"String\">Unique MfrLabel count</Data></Cell><Cell><Data ss:Type=\"Number\">" + distinctMfrLabels.Count.ToString() + "</Data></Cell></Row>");
                    sw.Write("<Row><Cell><Data ss:Type=\"String\">Unique Parttypes count</Data></Cell><Cell><Data ss:Type=\"Number\">" + distinctPartTypes.Count.ToString() + "</Data></Cell></Row>");
                    sw.Write("<Row><Cell><Data ss:Type=\"String\">Validation tool</Data></Cell><Cell ss:StyleID=\"s64\" ss:HRef=\"https://autopartsource.com/ACESinspector\"><Data ss:Type=\"String\">ACESinspector version " + codeVersion + "</Data></Cell></Row>");
                    sw.Write("</Table><WorksheetOptions xmlns=\"urn:schemas-microsoft-com:office:excel\"><PageSetup><Header x:Margin=\"0.3\"/><Footer x:Margin=\"0.3\"/><PageMargins x:Bottom=\"0.75\" x:Left=\"0.7\" x:Right=\"0.7\" x:Top=\"0.75\"/></PageSetup><Selected/><ProtectObjects>False</ProtectObjects><ProtectScenarios>False</ProtectScenarios></WorksheetOptions></Worksheet>");

                    
                    sw.Write("<Worksheet ss:Name=\"Parts\"><Table ss:ExpandedColumnCount=\"4\" x:FullColumns=\"1\" x:FullRows=\"1\" ss:DefaultRowHeight=\"15\"><Column ss:Width=\"100\"/><Column ss:Width=\"100\"/><Column ss:Width=\"100\"/><Column ss:Width=\"100\"/><Row><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Part</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Applications Count</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Part Types</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Positions</Data></Cell></Row>");
                    foreach (string distinctPart in distinctParts)
                    {
                        string[] partTypeIdStrings = partsPartTypes[distinctPart].Split('\t');
                        partTypeNameListString = ""; foreach (string partTypeIdString in partTypeIdStrings) { partTypeNameListString += pcdb.niceParttype(Convert.ToInt32(partTypeIdString)) + ","; }
                        partTypeNameListString = partTypeNameListString.Substring(0, partTypeNameListString.Length - 1);
                        string[] positionIdStrings = partsPositions[distinctPart].Split(',');
                        positionNameListString = ""; foreach (string positionIdString in positionIdStrings) { positionNameListString += pcdb.nicePosition(Convert.ToInt32(positionIdString)) + ","; }
                        positionNameListString = positionNameListString.Substring(0, positionNameListString.Length - 1);
                        sw.Write("<Row><Cell><Data ss:Type=\"String\">" + distinctPart + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + partsAppsCounts[distinctPart].ToString() + "</Data></Cell><Cell><Data ss:Type=\"String\">" + partTypeNameListString + "</Data></Cell><Cell><Data ss:Type=\"String\">" + positionNameListString + "</Data></Cell></Row>");
                    }
                    sw.Write("</Table><WorksheetOptions xmlns=\"urn:schemas-microsoft-com:office:excel\"><PageSetup><Header x:Margin=\"0.3\"/><Footer x:Margin=\"0.3\"/><PageMargins x:Bottom=\"0.75\" x:Left=\"0.7\" x:Right=\"0.7\" x:Top=\"0.75\"/></PageSetup><FreezePanes/><FrozenNoSplit/><SplitHorizontal>1</SplitHorizontal><TopRowBottomPane>1</TopRowBottomPane><ActivePane>2</ActivePane><Panes><Pane><Number>3</Number></Pane><Pane><Number>2</Number><ActiveRow>0</ActiveRow></Pane></Panes><ProtectObjects>False</ProtectObjects><ProtectScenarios>False</ProtectScenarios></WorksheetOptions></Worksheet>");

                    sw.Write("<Worksheet ss:Name=\"Part Types\"><Table ss:ExpandedColumnCount=\"2\" x:FullColumns=\"1\" x:FullRows=\"1\" ss:DefaultRowHeight=\"15\"><Column ss:Index=\"2\" ss:AutoFitWidth=\"0\" ss:Width=\"183.75\"/>");
                    foreach (int distinctPartType in distinctPartTypes) { sw.Write("<Row><Cell><Data ss:Type=\"Number\">" + distinctPartType + "</Data></Cell><Cell><Data ss:Type=\"String\">" + pcdb.niceParttype(distinctPartType) + "</Data></Cell></Row>"); }
                    sw.Write("</Table><WorksheetOptions xmlns=\"urn:schemas-microsoft-com:office:excel\"><PageSetup><Header x:Margin=\"0.3\"/><Footer x:Margin=\"0.3\"/><PageMargins x:Bottom=\"0.75\" x:Left=\"0.7\" x:Right=\"0.7\" x:Top=\"0.75\"/></PageSetup><ProtectObjects>False</ProtectObjects><ProtectScenarios>False</ProtectScenarios></WorksheetOptions></Worksheet>");

                    if(distinctMfrLabels.Count > 0)
                    {
                        sw.Write("<Worksheet ss:Name=\"MfrLabels\"><Table ss:ExpandedColumnCount=\"1\" x:FullColumns=\"1\" x:FullRows=\"1\" ss:DefaultRowHeight=\"15\"><Column ss:AutoFitWidth=\"0\" ss:Width=\"151.5\"/>");
                        foreach (string distinctMfrLabel in distinctMfrLabels) { sw.Write("<Row><Cell><Data ss:Type=\"String\">" + distinctMfrLabel + "</Data></Cell></Row>"); }
                        sw.Write("</Table><WorksheetOptions xmlns=\"urn:schemas-microsoft-com:office:excel\"><PageSetup><Header x:Margin=\"0.3\"/><Footer x:Margin=\"0.3\"/><PageMargins x:Bottom=\"0.75\" x:Left=\"0.7\" x:Right=\"0.7\" x:Top=\"0.75\"/></PageSetup><ProtectObjects>False</ProtectObjects><ProtectScenarios>False</ProtectScenarios></WorksheetOptions></Worksheet>");
                    }

                    if (parttypeDisagreementErrors.Count > 0)
                    {
                        sw.Write("<Worksheet ss:Name=\"Parttype Disagreement\"><Table ss:ExpandedColumnCount=\"2\" x:FullColumns=\"1\" x:FullRows=\"1\" ss:DefaultRowHeight=\"15\"><Column ss:AutoFitWidth=\"0\" ss:Width=\"45\"/><Column ss:AutoFitWidth=\"0\" ss:Width=\"78.75\"/><Row><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Part</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Parttypes</Data></Cell></Row>");
                        foreach (string line in parttypeDisagreementErrors)
                        {
                            string[] fileds = line.Split('\t');
                            sw.Write("<Row><Cell><Data ss:Type=\"String\">" + fileds[0] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[1] + "</Data></Cell></Row>");
                        }
                        excelTabColorXMLtag = "<TabColorIndex>13</TabColorIndex>";
                        sw.Write("</Table><WorksheetOptions xmlns=\"urn:schemas-microsoft-com:office:excel\"><PageSetup><Header x:Margin=\"0.3\"/><Footer x:Margin=\"0.3\"/><PageMargins x:Bottom=\"0.75\" x:Left=\"0.7\" x:Right=\"0.7\" x:Top=\"0.75\"/></PageSetup>" + excelTabColorXMLtag + "<FreezePanes/><FrozenNoSplit/><SplitHorizontal>1</SplitHorizontal><TopRowBottomPane>1</TopRowBottomPane><ActivePane>2</ActivePane><Panes><Pane><Number>3</Number></Pane><Pane><Number>2</Number><ActiveRow>0</ActiveRow></Pane></Panes><ProtectObjects>False</ProtectObjects><ProtectScenarios>False</ProtectScenarios></WorksheetOptions></Worksheet>");
                    }

                    if (overlapsErrors.Count > 0)
                    {
                        sw.Write("<Worksheet ss:Name=\"Overlaps\"><Table ss:ExpandedColumnCount=\"8\" x:FullColumns=\"1\" x:FullRows=\"1\" ss:DefaultRowHeight=\"15\"><Column ss:AutoFitWidth=\"0\" ss:Width=\"45\"/><Column ss:AutoFitWidth=\"0\" ss:Width=\"78.75\"/><Column ss:AutoFitWidth=\"0\" ss:Width=\"99.75\"/><Column ss:Width=\"31.5\"/><Column ss:AutoFitWidth=\"0\" ss:Width=\"60\"/><Column ss:AutoFitWidth=\"0\" ss:Width=\"112.5\"/><Column ss:Width=\"43.5\"/><Column ss:AutoFitWidth=\"0\" ss:Width=\"319.5\"/><Row><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">BaseVehcile Id</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Make</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Model</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Year</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Part Type</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Position</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Qualifiers</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Parts</Data></Cell></Row>");
                        foreach (string line in overlapsErrors)
                        {
                            string[] fileds = line.Split('\t');
                            sw.Write("<Row><Cell><Data ss:Type=\"Number\">" + fileds[0] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[1] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[2] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[3] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[4] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[5] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[6] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[7] + "</Data></Cell></Row>");
                        }
                        excelTabColorXMLtag = "<TabColorIndex>10</TabColorIndex>";
                        sw.Write("</Table><WorksheetOptions xmlns=\"urn:schemas-microsoft-com:office:excel\"><PageSetup><Header x:Margin=\"0.3\"/><Footer x:Margin=\"0.3\"/><PageMargins x:Bottom=\"0.75\" x:Left=\"0.7\" x:Right=\"0.7\" x:Top=\"0.75\"/></PageSetup>" + excelTabColorXMLtag + "<FreezePanes/><FrozenNoSplit/><SplitHorizontal>1</SplitHorizontal><TopRowBottomPane>1</TopRowBottomPane><ActivePane>2</ActivePane><Panes><Pane><Number>3</Number></Pane><Pane><Number>2</Number><ActiveRow>0</ActiveRow></Pane></Panes><ProtectObjects>False</ProtectObjects><ProtectScenarios>False</ProtectScenarios></WorksheetOptions></Worksheet>");
                    }


                    if (CNCoverlapsErrors.Count > 0)
                    {
                        sw.Write("<Worksheet ss:Name=\"CNC Overlaps\"><Table ss:ExpandedColumnCount=\"11\" x:FullColumns=\"1\" x:FullRows=\"1\" ss:DefaultRowHeight=\"15\"><Column ss:Width=\"100\"/><Column ss:Width=\"100\"/><Column ss:Width=\"100\"/><Column ss:Width=\"100\"/><Column ss:Width=\"100\"/><Column ss:Width=\"100\"/><Column ss:Width=\"100\"/><Column ss:Width=\"100\"/><Column ss:Width=\"100\"/><Column ss:Width=\"100\"/><Column ss:Width=\"100\"/><Row><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">CNC Group</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">App Id</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">BaseVehcile Id</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Make</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Model</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Year</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Part Type</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Position</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Quantity</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Part</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Qualifiers</Data></Cell></Row>");
                        foreach (string line in CNCoverlapsErrors)
                        {
                            string[] fileds = line.Split('\t');
                            //sw.Write("<Row><Cell><Data ss:Type=\"Number\">" + fileds[0] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[1] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[2] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[3] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[4] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[5] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[6] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[7] + "</Data></Cell></Row>");
                            sw.Write("<Row><Cell><Data ss:Type=\"Number\">" + fileds[0] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + fileds[1] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + fileds[2] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[3] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[4] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[5] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[6] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[7] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + fileds[8] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[9] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[10] + "</Data></Cell></Row>");
                        }
                        excelTabColorXMLtag = "<TabColorIndex>10</TabColorIndex>";
                        sw.Write("</Table><WorksheetOptions xmlns=\"urn:schemas-microsoft-com:office:excel\"><PageSetup><Header x:Margin=\"0.3\"/><Footer x:Margin=\"0.3\"/><PageMargins x:Bottom=\"0.75\" x:Left=\"0.7\" x:Right=\"0.7\" x:Top=\"0.75\"/></PageSetup>" + excelTabColorXMLtag + "<FreezePanes/><FrozenNoSplit/><SplitHorizontal>1</SplitHorizontal><TopRowBottomPane>1</TopRowBottomPane><ActivePane>2</ActivePane><Panes><Pane><Number>3</Number></Pane><Pane><Number>2</Number><ActiveRow>0</ActiveRow></Pane></Panes><ProtectObjects>False</ProtectObjects><ProtectScenarios>False</ProtectScenarios></WorksheetOptions></Worksheet>");
                    }



                    if (basevehicleidsErrors.Count > 0)
                    {
                        sw.Write("<Worksheet ss:Name =\"Invalid Base Vids\"><Table ss:ExpandedColumnCount=\"7\" x:FullColumns=\"1\" x:FullRows=\"1\" ss:DefaultRowHeight=\"15\"><Column ss:AutoFitWidth=\"0\" ss:Width=\"45\"/><Column ss:Width=\"77.25\"/><Column ss:Index=\"4\" ss:AutoFitWidth=\"0\" ss:Width=\"96\"/><Column ss:AutoFitWidth=\"0\" ss:Width=\"73.5\"/><Column ss:AutoFitWidth=\"0\" ss:Width=\"253.5\"/><Column ss:AutoFitWidth=\"0\" ss:Width=\"371.25\"/><Row><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">App Id</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Invalid BaseVid</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Part Type</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Position</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Quantity</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Part</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Qualifiers</Data></Cell></Row>");
                        foreach (string line in basevehicleidsErrors)
                        {
                            string[] fileds = line.Split('\t');
                            sw.Write("<Row><Cell><Data ss:Type=\"Number\">" + fileds[0] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + fileds[1] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[2] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[3] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + fileds[4] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[5] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[6] + "</Data></Cell></Row>");
                        }
                        excelTabColorXMLtag = "<TabColorIndex>10</TabColorIndex>";
                        sw.Write("</Table><WorksheetOptions xmlns=\"urn:schemas-microsoft-com:office:excel\"><PageSetup><Header x:Margin=\"0.3\"/><Footer x:Margin=\"0.3\"/><PageMargins x:Bottom=\"0.75\" x:Left=\"0.7\" x:Right=\"0.7\" x:Top=\"0.75\"/></PageSetup><Print><ValidPrinterInfo/><HorizontalResolution>600</HorizontalResolution><VerticalResolution>600</VerticalResolution></Print>" + excelTabColorXMLtag + "<FreezePanes/><FrozenNoSplit/><SplitHorizontal>1</SplitHorizontal><TopRowBottomPane>1</TopRowBottomPane><ActivePane>2</ActivePane><Panes><Pane><Number>3</Number></Pane><Pane><Number>2</Number><ActiveRow>0</ActiveRow></Pane></Panes><ProtectObjects>False</ProtectObjects><ProtectScenarios>False</ProtectScenarios></WorksheetOptions></Worksheet>");
                    }

                    if(vcdbCodesErrors.Count > 0)
                    {
                        sw.Write("<Worksheet ss:Name=\"Invalid VCdb Codes\"><Table ss:ExpandedColumnCount=\"10\" x:FullColumns=\"1\" x:FullRows=\"1\" ss:DefaultRowHeight=\"15\"><Column ss:AutoFitWidth=\"0\" ss:Width=\"45\"/><Column ss:AutoFitWidth=\"0\" ss:Width=\"78.75\"/><Column ss:AutoFitWidth=\"0\" ss:Width=\"99.75\"/><Column ss:Width=\"31.5\"/><Column ss:AutoFitWidth=\"0\" ss:Width=\"60\"/><Column ss:AutoFitWidth=\"0\" ss:Width=\"112.5\"/><Column ss:Width=\"43.5\"/><Column ss:Width =\"43.5\"/><Column ss:AutoFitWidth=\"0\" ss:Width=\"237\"/><Column ss:AutoFitWidth=\"0\" ss:Width=\"319.5\"/><Row><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">App Id</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Make</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Model</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Year</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Part Type</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Position</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Quantity</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Part</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">VCdb Attributes</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Notes</Data></Cell></Row>");
                        foreach (string line in vcdbCodesErrors)
                        {
                            string[] fileds = line.Split('\t');
                            sw.Write("<Row><Cell><Data ss:Type=\"Number\">" + fileds[0] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[1] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[2] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[3] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[4] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[5] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + fileds[6] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[7] + "</Data></Cell><Cell><Data ss:Type =\"String\">" + fileds[8] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[9] + "</Data></Cell></Row>");
                        }
                        excelTabColorXMLtag = "<TabColorIndex>10</TabColorIndex>";
                        sw.Write("</Table><WorksheetOptions xmlns=\"urn:schemas-microsoft-com:office:excel\"><PageSetup><Header x:Margin=\"0.3\"/><Footer x:Margin=\"0.3\"/><PageMargins x:Bottom=\"0.75\" x:Left=\"0.7\" x:Right=\"0.7\" x:Top=\"0.75\"/></PageSetup>" + excelTabColorXMLtag + "<FreezePanes/><FrozenNoSplit/><SplitHorizontal>1</SplitHorizontal><TopRowBottomPane>1</TopRowBottomPane><ActivePane>2</ActivePane><Panes><Pane><Number>3</Number></Pane><Pane><Number>2</Number><ActiveRow>0</ActiveRow></Pane></Panes><ProtectObjects>False</ProtectObjects><ProtectScenarios>False</ProtectScenarios></WorksheetOptions></Worksheet>");
                    }


                    if (vcdbConfigurationsErrors.Count > 0)
                    {
                        sw.Write("<Worksheet ss:Name=\"Invalid VCdb Configs\"><Table ss:ExpandedColumnCount=\"10\" x:FullColumns=\"1\" x:FullRows=\"1\" ss:DefaultRowHeight=\"15\"><Column ss:AutoFitWidth=\"0\" ss:Width=\"45\"/><Column ss:AutoFitWidth=\"0\" ss:Width=\"78.75\"/><Column ss:AutoFitWidth=\"0\" ss:Width=\"99.75\"/><Column ss:Width=\"31.5\"/><Column ss:AutoFitWidth=\"0\" ss:Width=\"60\"/><Column ss:AutoFitWidth=\"0\" ss:Width=\"112.5\"/><Column ss:Width=\"43.5\"/><Column ss:Width =\"43.5\"/><Column ss:AutoFitWidth=\"0\" ss:Width=\"237\"/><Column ss:AutoFitWidth=\"0\" ss:Width=\"319.5\"/><Row><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">App Id</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Make</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Model</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Year</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Part Type</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Position</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Quantity</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Part</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">VCdb Attributes</Data></Cell><Cell ss:StyleID=\"s65\"><Data ss:Type=\"String\">Notes</Data></Cell></Row>");
                        foreach (string line in vcdbConfigurationsErrors)
                        {
                            string[] fileds = line.Split('\t');
                            sw.Write("<Row><Cell><Data ss:Type=\"Number\">" + fileds[0] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[1] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[2] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[3] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[4] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[5] + "</Data></Cell><Cell><Data ss:Type=\"Number\">" + fileds[6] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[7] + "</Data></Cell><Cell><Data ss:Type =\"String\">" + fileds[8] + "</Data></Cell><Cell><Data ss:Type=\"String\">" + fileds[9] + "</Data></Cell></Row>");
                        }
                        excelTabColorXMLtag = "<TabColorIndex>10</TabColorIndex>";
                        sw.Write("</Table><WorksheetOptions xmlns=\"urn:schemas-microsoft-com:office:excel\"><PageSetup><Header x:Margin=\"0.3\"/><Footer x:Margin=\"0.3\"/><PageMargins x:Bottom=\"0.75\" x:Left=\"0.7\" x:Right=\"0.7\" x:Top=\"0.75\"/></PageSetup>" + excelTabColorXMLtag + "<FreezePanes/><FrozenNoSplit/><SplitHorizontal>1</SplitHorizontal><TopRowBottomPane>1</TopRowBottomPane><ActivePane>2</ActivePane><Panes><Pane><Number>3</Number></Pane><Pane><Number>2</Number><ActiveRow>0</ActiveRow></Pane></Panes><ProtectObjects>False</ProtectObjects><ProtectScenarios>False</ProtectScenarios></WorksheetOptions></Worksheet>");
                    }

                    sw.Write("</Workbook>");
                }
                return "Assessment file (" + _filePath + ") generated";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }


        public string exportFlatApps(string _filePath, VCdb vcdb, PCdb pcdb)
        {
            BaseVehicle basevehicle = new BaseVehicle();
            try
            {
                using (StreamWriter sw = new StreamWriter(_filePath))
                {
                    foreach (App app in apps)
                    {
                        sw.WriteLine(app.id.ToString() + "\t" + vcdb.niceMakeOfBasevid(app.basevehilceid) + "\t" + vcdb.niceModelOfBasevid(app.basevehilceid) + "\t" + vcdb.niceYearOfBasevid(app.basevehilceid) + "\t" + app.part + "\t" + pcdb.niceParttype(app.parttypeid) + "\t" + pcdb.nicePosition(app.positionid) + "\t" + app.quantity.ToString() + "\t" + app.niceAttributesString(vcdb, false) + "\t" + app.notes + "\t" + app.mfrlabel);
                    }
                }
                return "Flat applications exported to " + _filePath;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }




        public string exportBuyersGuide(string _filePath, VCdb vcdb, IProgress<int> progress)
        {
            int i; bool deletedElement; string lineString = ""; int percentProgress = 0;
            List<buyersguideApplication> bg = new List<buyersguideApplication>();
            foreach (App app in apps)
            {
                buyersguideApplication bgAppTemp = new buyersguideApplication();
                bgAppTemp.part = app.part;
                bgAppTemp.MakeName = vcdb.niceMakeOfBasevid(app.basevehilceid);
                bgAppTemp.ModelName = vcdb.niceModelOfBasevid(app.basevehilceid);
                bgAppTemp.startYear= Convert.ToInt32(vcdb.niceYearOfBasevid(app.basevehilceid));
                bgAppTemp.endYear = bgAppTemp.startYear;
                bg.Add(bgAppTemp);
            }
            bg.Sort();


            deletedElement = true;
            while (deletedElement)
            {
                deletedElement = false;
                for (i = 0; i <= bg.Count() - 2; i++)
                {
                    if (bg[i].part == bg[i + 1].part &&  bg[i].MakeName == bg[i + 1].MakeName && bg[i].ModelName == bg[i + 1].ModelName &&   (bg[i + 1].startYear - bg[i].endYear)<=1)
                    {
                        bg[i].endYear = bg[i + 1].startYear;
                        deletedElement = true;
                        break;
                    }
                }
                if (deletedElement)
                {
                    bg.RemoveAt(i + 1);
                    if (progress != null)
                    {// only report progress on whole percentage steps (100 total reports). reporting on every iteration is too process intensive
                        percentProgress = Convert.ToInt32(((double)i / (double)bg.Count()) * 100);
                        if ((double)percentProgress % (double)1 == 0) { progress.Report(percentProgress); }
                    }

                }
            }


            try
            {
                using (StreamWriter sw = new StreamWriter(_filePath))
                {
                    lineString = bg[0].part + "\t";
                    for (i=0; i<=bg.Count()-1; i++)
                    {
                        if (i == (bg.Count() - 1) || bg[i].part != bg[i + 1].part)
                        {// new part (or final element)

                            if (bg[i].startYear == bg[i].endYear)
                            {
                                lineString += bg[i].MakeName + " " + bg[i].ModelName + " (" + bg[i].startYear.ToString() + ")";
                            }
                            else
                            {
                                lineString += bg[i].MakeName + " " + bg[i].ModelName + " (" + bg[i].startYear.ToString() + "-" + bg[i].endYear.ToString() + ")";
                            }
                            sw.WriteLine(lineString);
                            if (i < (bg.Count() - 1)) { lineString = bg[i + 1].part + "\t"; }
                        }
                        else
                        {// same part as last element

                            if (bg[i].startYear == bg[i].endYear)
                            {
                                lineString += bg[i].MakeName + " " + bg[i].ModelName + " (" + bg[i].startYear.ToString() + "), ";
                            }
                            else
                            {
                                lineString += bg[i].MakeName + " " + bg[i].ModelName + " (" + bg[i].startYear.ToString() + "-" + bg[i].endYear.ToString() + "), ";
                            }
                        }
                    }
                }
                return "Buyer's guide exported to " + _filePath;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }







    }




    public class VCdb
    {
        public OleDbConnection vcdbConnection = new OleDbConnection();
        public string filePath="";
        public string version="";

        // the fundemental elements of the VCdb are loaded into hash tables ("Dictionaries") for the sake of speed.
        // there is about a 3x speed advandage of doing code validation against in-memory hash tables vs. querying the database
        // the memory cost is trivial. At database load time, a query is executed for each dictionary.
        public Dictionary<int, BaseVehicle> basevid = new Dictionary<int, BaseVehicle>();
        public Dictionary<int, String> enginebase = new Dictionary<int, string>();
        public Dictionary<int, String> submodel = new Dictionary<int, string>();
        public Dictionary<int, String> drivetype = new Dictionary<int, string>();
        public Dictionary<int, String> aspiration = new Dictionary<int, string>();
        public Dictionary<int, String> fueltype = new Dictionary<int, string>();
        public Dictionary<int, String> braketype = new Dictionary<int, string>();
        public Dictionary<int, String> brakeabs = new Dictionary<int, string>();
        public Dictionary<int, String> mfrbodycode = new Dictionary<int, string>();
        public Dictionary<int, String> bodynumdoors = new Dictionary<int, string>();
        public Dictionary<int, String> bodytype = new Dictionary<int, string>();
        public Dictionary<int, String> enginedesignation = new Dictionary<int, string>();
        public Dictionary<int, String> enginevin = new Dictionary<int, string>();
        public Dictionary<int, String> engineversion = new Dictionary<int, string>();
        public Dictionary<int, String> mfr = new Dictionary<int, string>();
        public Dictionary<int, String> fueldeliverytype = new Dictionary<int, string>();
        public Dictionary<int, String> fueldeliverysubtype = new Dictionary<int, string>();
        public Dictionary<int, String> fuelsystemcontroltype = new Dictionary<int, string>();
        public Dictionary<int, String> fuelsystemdesign = new Dictionary<int, string>();
        public Dictionary<int, String> cylinderheadtype = new Dictionary<int, string>();
        public Dictionary<int, String> ignitionsystemtype = new Dictionary<int, string>();
        public Dictionary<int, String> transmissionmfrcode = new Dictionary<int, string>();
        public Dictionary<int, String> transmissionbase = new Dictionary<int, string>();
        public Dictionary<int, String> transmissiontype = new Dictionary<int, string>();
        public Dictionary<int, String> transmissioncontroltype = new Dictionary<int, string>();
        public Dictionary<int, String> transmissionnumspeeds = new Dictionary<int, string>();
        public Dictionary<int, String> bedlength = new Dictionary<int, string>();
        public Dictionary<int, String> bedtype = new Dictionary<int, string>();
        public Dictionary<int, String> wheelbase = new Dictionary<int, string>();
        public Dictionary<int, String> brakesystem = new Dictionary<int, string>();
        public Dictionary<int, String> region = new Dictionary<int, string>();
        public Dictionary<int, String> springtype = new Dictionary<int, string>();
        public Dictionary<int, String> steeringsystem = new Dictionary<int, string>();
        public Dictionary<int, String> steeringtype = new Dictionary<int, string>();
        public Dictionary<int, String> valves = new Dictionary<int, string>();


        public void connect(string _filePath)
        {
            filePath = _filePath;
            if (vcdbConnection.State == System.Data.ConnectionState.Closed)
            {
                vcdbConnection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + _filePath + ";Mode=Read";
                vcdbConnection.Open();
            }
        }

        public void disconnect()
        {
            filePath = "";
            if (vcdbConnection.State != System.Data.ConnectionState.Closed)
            {
                vcdbConnection.Close();
            }
        }



        public void clear()
        {
            filePath = "";
            version = "";
            basevid.Clear();
            enginebase.Clear();
            submodel.Clear();
            drivetype.Clear();
            aspiration.Clear();
            fueltype.Clear();
            braketype.Clear();
            brakeabs.Clear();
            mfrbodycode.Clear();
            bodynumdoors.Clear();
            bodytype.Clear();
            enginedesignation.Clear();
            enginevin.Clear();
            engineversion.Clear();
            mfr.Clear();
            fueldeliverytype.Clear();
            fueldeliverysubtype.Clear();
            fuelsystemcontroltype.Clear();
            fuelsystemdesign.Clear();
            cylinderheadtype.Clear();
            ignitionsystemtype.Clear();
            transmissionmfrcode.Clear();
            transmissionbase.Clear();
            transmissiontype.Clear();
            transmissioncontroltype.Clear();
            transmissionnumspeeds.Clear();
            bedlength.Clear();
            bedtype.Clear();
            wheelbase.Clear();
            brakesystem.Clear();
            region.Clear();
            springtype.Clear();
            steeringsystem.Clear();
            steeringtype.Clear();
            valves.Clear();
        }


        public string niceAttribute(VCdbAttribute attribute)
        {

            string niceValue = "";
            string returnValue = "";
            bool gotValue = false;

            switch (attribute.name)
            {
                case "EngineBase": gotValue = enginebase.TryGetValue(attribute.value, out niceValue); break;
                case "SubModel": gotValue = submodel.TryGetValue(attribute.value, out niceValue); break;
                case "DriveType": gotValue = drivetype.TryGetValue(attribute.value, out niceValue); break;
                case "Aspiration": gotValue = aspiration.TryGetValue(attribute.value, out niceValue); break;
                case "FuelType": gotValue = fueltype.TryGetValue(attribute.value, out niceValue); break;
                case "FrontBrakeType": gotValue = braketype.TryGetValue(attribute.value, out niceValue); break;
                case "RearBrakeType": gotValue = braketype.TryGetValue(attribute.value, out niceValue); break;
                case "BrakeABS": gotValue = brakeabs.TryGetValue(attribute.value, out niceValue); break;
                case "MfrBodyCode": gotValue = mfrbodycode.TryGetValue(attribute.value, out niceValue); break;
                case "BodyNumDoors": gotValue = bodynumdoors.TryGetValue(attribute.value, out niceValue); break;
                case "BodyType": gotValue = bodytype.TryGetValue(attribute.value, out niceValue); break;
                case "EngineDesignation": gotValue = enginedesignation.TryGetValue(attribute.value, out niceValue); break;
                case "EngineVIN": gotValue = enginevin.TryGetValue(attribute.value, out niceValue); break;
                case "EngineVersion": gotValue = engineversion.TryGetValue(attribute.value, out niceValue); break;
                //case "EngineMfr": gotValue = enginebase.TryGetValue(attribute.value, out niceValue); break;   // changed in 1.0.1.12 - Edgenet's devteam spotted this error
                case "EngineMfr": gotValue =  mfr.TryGetValue(attribute.value, out niceValue); break;
                case "FuelDeliveryType": gotValue = fueldeliverytype.TryGetValue(attribute.value, out niceValue); break;
                case "FuelDeliverySubType": gotValue = fueldeliverysubtype.TryGetValue(attribute.value, out niceValue); break;
                case "FuelSystemControlType": gotValue = fuelsystemcontroltype.TryGetValue(attribute.value, out niceValue); break;
                case "FuelSystemDesign": gotValue = fuelsystemdesign.TryGetValue(attribute.value, out niceValue); break;
                case "CylinderHeadType": gotValue = cylinderheadtype.TryGetValue(attribute.value, out niceValue); break;
                case "IgnitionSystemType": gotValue = ignitionsystemtype.TryGetValue(attribute.value, out niceValue); break;
                case "TransmissionMfrCode": gotValue = transmissionmfrcode.TryGetValue(attribute.value, out niceValue); break;
                case "TransmissionBase": gotValue = transmissionbase.TryGetValue(attribute.value, out niceValue); break;
                case "TransmissionType": gotValue = transmissiontype.TryGetValue(attribute.value, out niceValue); break;
                case "TransmissionControlType": gotValue = transmissioncontroltype.TryGetValue(attribute.value, out niceValue); break;
                case "TransmissionNumSpeeds": gotValue = transmissionnumspeeds.TryGetValue(attribute.value, out niceValue); break;
                case "TransmissionMfr": gotValue = mfr.TryGetValue(attribute.value, out niceValue); break;
                case "BedLength": gotValue = bedlength.TryGetValue(attribute.value, out niceValue); break;
                case "BedType": gotValue = bedtype.TryGetValue(attribute.value, out niceValue); break;
                case "WheelBase": gotValue = wheelbase.TryGetValue(attribute.value, out niceValue); break;
                case "BrakeSystem": gotValue = brakesystem.TryGetValue(attribute.value, out niceValue); break;
                case "Region": gotValue = region.TryGetValue(attribute.value, out niceValue); break;
                case "FrontSpringType": gotValue = springtype.TryGetValue(attribute.value, out niceValue); break;
                case "RearSpringType": gotValue = springtype.TryGetValue(attribute.value, out niceValue); break;
                case "SteeringSystem": gotValue = steeringsystem.TryGetValue(attribute.value, out niceValue); break;
                case "SteeringType": gotValue = steeringtype.TryGetValue(attribute.value, out niceValue); break;
                case "ValvesPerEngine": gotValue = valves.TryGetValue(attribute.value, out niceValue); break;
                default: gotValue = false; break;
            }

            if (gotValue)
            {
                switch (attribute.name)
                {
                    case "MfrBodyCode": returnValue = "Body code " + niceValue; break;
                    case "BodyNumDoors": returnValue = niceValue + " Door"; break;
                    case "EngineVIN": returnValue = "VIN:" + niceValue; break;
                    case "TransmissionMfrCode": returnValue = niceValue + " Transmission"; break;
                    case "TransmissionControlType": returnValue = niceValue + " Transmission"; break;
                    case "TransmissionNumSpeeds": returnValue = niceValue + " Speed Transmission"; break;
                    case "TransmissionMfr": returnValue = niceValue + " Transmission"; break;
                    case "BedLength": returnValue = niceValue + " Inch Bed"; break;
                    case "BedType": returnValue = niceValue + " Bed"; break;
                    case "WheelBase": returnValue = niceValue + " Inch Wheelbase"; break;
                    case "BrakeSystem": returnValue = niceValue + " Brakes"; break;
                    case "FrontBrakeType": returnValue = "Front " + niceValue; break;
                    case "RearBrakeType": returnValue = "Rear " + niceValue; break;
                    case "FrontSpringType": returnValue = "Front " + niceValue + " Suspenssion"; break;
                    case "RearSpringType": returnValue = "Rear " + niceValue + " Suspenssion"; break;
                    case "SteeringSystem": returnValue = niceValue + " Steering"; break;
                    case "SteeringType": returnValue = niceValue + " Steering"; break;
                    case "ValvesPerEngine": returnValue = niceValue + " Valve"; break;
                    default: returnValue = niceValue; break;
                }
            }
            else
            {
                returnValue = "invalid (" + attribute.name + "=" + attribute.value + ")";
            }
            return returnValue;
        }



        public bool validAttribute(VCdbAttribute attribute)
        {
            string niceValue = "";
            switch (attribute.name)
            {
                case "EngineBase": return enginebase.TryGetValue(attribute.value, out niceValue);
                case "SubModel": return submodel.TryGetValue(attribute.value, out niceValue);
                case "DriveType": return drivetype.TryGetValue(attribute.value, out niceValue);
                case "Aspiration": return aspiration.TryGetValue(attribute.value, out niceValue);
                case "FuelType": return fueltype.TryGetValue(attribute.value, out niceValue);
                case "FrontBrakeType": return braketype.TryGetValue(attribute.value, out niceValue);
                case "RearBrakeType": return braketype.TryGetValue(attribute.value, out niceValue);
                case "BrakeABS": return brakeabs.TryGetValue(attribute.value, out niceValue);
                case "MfrBodyCode": return mfrbodycode.TryGetValue(attribute.value, out niceValue);
                case "BodyNumDoors": return bodynumdoors.TryGetValue(attribute.value, out niceValue);
                case "BodyType": return bodytype.TryGetValue(attribute.value, out niceValue);
                case "EngineDesignation": return enginedesignation.TryGetValue(attribute.value, out niceValue);
                case "EngineVIN": return enginevin.TryGetValue(attribute.value, out niceValue);
                case "EngineVersion": return engineversion.TryGetValue(attribute.value, out niceValue);
                //case "EngineMfr": return enginebase.TryGetValue(attribute.value, out niceValue); // changed in 1.0.1.12 - Edgenet's devteam spotted this error
                case "EngineMfr": return mfr.TryGetValue(attribute.value, out niceValue);
                case "FuelDeliveryType": return fueldeliverytype.TryGetValue(attribute.value, out niceValue);
                case "FuelDeliverySubType": return fueldeliverysubtype.TryGetValue(attribute.value, out niceValue);
                case "FuelSystemControlType": return fuelsystemcontroltype.TryGetValue(attribute.value, out niceValue);
                case "FuelSystemDesign": return fuelsystemdesign.TryGetValue(attribute.value, out niceValue);
                case "CylinderHeadType": return cylinderheadtype.TryGetValue(attribute.value, out niceValue);
                case "IgnitionSystemType": return ignitionsystemtype.TryGetValue(attribute.value, out niceValue);
                case "TransmissionMfrCode": return transmissionmfrcode.TryGetValue(attribute.value, out niceValue);
                case "TransmissionBase": return transmissionbase.TryGetValue(attribute.value, out niceValue);
                case "TransmissionType": return transmissiontype.TryGetValue(attribute.value, out niceValue);
                case "TransmissionControlType": return transmissioncontroltype.TryGetValue(attribute.value, out niceValue);
                case "TransmissionNumSpeeds": return transmissionnumspeeds.TryGetValue(attribute.value, out niceValue);
                case "TransmissionMfr": return mfr.TryGetValue(attribute.value, out niceValue);
                case "BedLength": return bedlength.TryGetValue(attribute.value, out niceValue);
                case "BedType": return bedtype.TryGetValue(attribute.value, out niceValue);
                case "WheelBase": return wheelbase.TryGetValue(attribute.value, out niceValue);
                case "BrakeSystem": return brakesystem.TryGetValue(attribute.value, out niceValue);
                case "Region": return region.TryGetValue(attribute.value, out niceValue);
                case "FrontSpringType": return springtype.TryGetValue(attribute.value, out niceValue);
                case "RearSpringType": return springtype.TryGetValue(attribute.value, out niceValue);
                case "SteeringSystem": return steeringsystem.TryGetValue(attribute.value, out niceValue);
                case "SteeringType": return steeringtype.TryGetValue(attribute.value, out niceValue);
                case "ValvesPerEngine": return valves.TryGetValue(attribute.value, out niceValue);
                default: return false;
            }
        }


        public string niceMakeOfBasevid(int baseVid)
        {
            BaseVehicle basevidTemp = new BaseVehicle(); //basevidTemp.MakeName = "";
            if (basevid.TryGetValue(baseVid, out basevidTemp))
            {
                return basevidTemp.MakeName;
            }
            else
            {
                return "not found";
            }
        }

        public string niceModelOfBasevid(int baseVid)
        {
            BaseVehicle basevidTemp = new BaseVehicle(); //basevidTemp.MakeName = "";
            if (basevid.TryGetValue(baseVid, out basevidTemp))
            {
                return basevidTemp.ModelName;
            }
            else
            {
                return "not found";
            }
        }

        public string niceYearOfBasevid(int baseVid)
        {
            BaseVehicle basevidTemp = new BaseVehicle(); //basevidTemp.MakeName = "";
            if (basevid.TryGetValue(baseVid, out basevidTemp))
            {
                return basevidTemp.YearId;
            }
            else
            {
                return "not found";
            }
        }



        public bool configIsValid(App app)
        {
            bool returnValue = false;
            string sqlString = "";
            if(app.VCdbAttributes.Count == 0){return true;}// apps with no attributes are inherently valid from a configuration standpoint

            sqlString = configValidationSQLForApp(app);
            try
            {
                OleDbCommand command = new OleDbCommand(sqlString, vcdbConnection);
                OleDbDataReader reader = command.ExecuteReader();
                if(reader.Read()){returnValue = true;}
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(sqlString);
            }
            return returnValue;
        }







        // Build the "from" and "where" sql tables and join clauses for vcdb validation query based on the attributes in the reference app.
        // The purpose is to tease out a list of attribute names for knowing which tables to validate against. You could simply validate every app against a monolithic "all-in-one" 
        // join of the entire vcdb - this is process-intensive (very slow). If we only include the tables in the join that the app referes-to, the query is faster and more memory effecient.
        public string configValidationSQLForApp(App app)
        {
            if (app.VCdbAttributes.Count == 0) { return ""; }

            string fromClause = "vehicle,";
            string whereClause = "";
            List<int> vcdbSystems = new List<int>();
            int i;

            foreach (VCdbAttribute myAttribute in app.VCdbAttributes)
            {
                i = systemGroupOfAttribute(myAttribute);
                if (!vcdbSystems.Contains(i)) { vcdbSystems.Add(i); }
            }

            foreach (int vcdbSystem in vcdbSystems)
            {
                switch (vcdbSystem)
                {
                    case 0: break; // vehilce is the only table required for determining region or submodel. fromClause is initialized to "vheicle," already
                    case 1: fromClause += "vehicletodrivetype,"; whereClause += "vehicle.vehicleid=vehicletodrivetype.vehicleid and "; break;
                    case 2: fromClause += "vehicletobrakeconfig,brakeconfig,"; whereClause += "vehicle.vehicleid=vehicletobrakeconfig.vehicleid and vehicletobrakeconfig.brakeconfigid=brakeconfig.brakeconfigid and "; break;
                    case 3: fromClause += "vehicletoengineconfig,engineconfig,valves,enginebase,fueldeliveryconfig,"; whereClause += "vehicle.vehicleid = vehicletoengineconfig.vehicleid and vehicletoengineconfig.engineconfigid = engineconfig.engineconfigid and engineconfig.enginebaseid=enginebase.enginebaseid and engineconfig.valvesid=valves.valvesid and engineconfig.fueldeliveryconfigid=fueldeliveryconfig.fueldeliveryconfigid and "; break;
                    case 4: fromClause += "vehicletobodystyleconfig,bodystyleconfig,"; whereClause += "vehicle.vehicleid=vehicletobodystyleconfig.vehicleid and vehicletobodystyleconfig.bodystyleconfigid = bodystyleconfig.bodystyleconfigid and "; break;
                    case 5: fromClause += "vehicletomfrbodycode,"; whereClause += "vehicle.vehicleid=vehicletomfrbodycode.vehicleid and "; break;
                    case 6: fromClause += "vehicletotransmission,transmission,transmissionbase,"; whereClause += "vehicle.vehicleid=vehicletotransmission.vehicleid and vehicletotransmission.transmissionid=transmission.transmissionid and  transmission.transmissionbaseid=transmissionbase.transmissionbaseid and "; break;
                    case 7: fromClause += "vehicletowheelbase,"; whereClause += "vehicle.vehicleid=vehicletowheelbase.vehicleid and "; break;
                    case 8: fromClause += "vehicletosteeringconfig,steeringconfig,"; whereClause += "vehicle.vehicleid=vehicletosteeringconfig.vehicleid and vehicletosteeringconfig.steeringconfigid=steeringconfig.steeringconfigid and "; break;
                    case 9: fromClause += "vehicletobedconfig,bedconfig,"; whereClause += "vehicle.vehicleid=vehicletobedconfig.vehicleid and vehicletobedconfig.bedconfigid=bedconfig.bedconfigid and "; break;
                    case 10: fromClause += "vehicletospringtypeconfig,springtypeconfig,"; whereClause += "vehicle.vehicleid=vehicletospringtypeconfig.vehicleid and vehicletospringtypeconfig.springtypeconfigid=springtypeconfig.springtypeconfigid and "; break;
                    case 11: fromClause += "basevehicle,model,"; whereClause += "basebehicle.modelid=model.modelid and "; break;
                    case 12: break;
                    default: break;
                }
            }

            if (fromClause.Length > 0) { fromClause = fromClause.Substring(0, fromClause.Length - 1); }

            foreach (VCdbAttribute myAttribute in app.VCdbAttributes)
            {
                whereClause += attributeWhereClause(myAttribute);
            }

            whereClause += "vehicle.basevehicleid = " + app.basevehilceid.ToString();

            return "select vehicle.vehicleid from " + fromClause + " where " + whereClause + ";";
        }


        public string attributeWhereClause(VCdbAttribute myAttribute)
        {
            switch (myAttribute.name)
            {
                case "EngineBase": return "enginebase.enginebaseid = " + myAttribute.value + " and ";
                case "SubModel": return "submodelid = " + myAttribute.value + " and ";
                case "DriveType": return "drivetypeid = " + myAttribute.value + " and ";
                case "Aspiration": return "aspirationid = " + myAttribute.value + " and ";
                case "FuelType": return "fueltypeid = " + myAttribute.value + " and ";
                case "FrontBrakeType": return "frontbraketypeid = " + myAttribute.value + " and ";
                case "RearBrakeType": return "rearbraketypeid = " + myAttribute.value + " and ";
                case "BrakeABS": return "brakeabsid = " + myAttribute.value + " and ";
                case "MfrBodyCode": return "mfrbodycodeid = " + myAttribute.value + " and ";
                case "BodyNumDoors": return "bodynumdoorsid = " + myAttribute.value + " and ";
                case "BodyType": return "bodytypeid = " + myAttribute.value + " and ";
                case "EngineDesignation": return "enginedesignationid = " + myAttribute.value + " and ";
                case "EngineVIN": return "enginevinid = " + myAttribute.value + " and ";
                case "EngineVersion": return "engineversionid = " + myAttribute.value + " and ";
                case "EngineMfr": return "mfrid = " + myAttribute.value + " and ";
                case "FuelDeliveryType": return "fueldeliverytypeid = " + myAttribute.value + " and ";
                case "FuelDeliverySubType": return "fueldeliverysubtypeid = " + myAttribute.value + " and ";
                case "FuelSystemControlType": return "fuelsystemcontroltypeid = " + myAttribute.value + " and ";
                case "FuelSystemDesign": return "fuelsystemdesignid = " + myAttribute.value + " and ";
                case "CylinderHeadType": return "cylinderheadtypeid = " + myAttribute.value + " and ";
                case "IgnitionSystemType": return "ignitionsystemtypeid = " + myAttribute.value + " and ";
                case "TransmissionMfrCode": return "transmissionmfrcodeid = " + myAttribute.value + " and ";
                case "TransmissionBase": return "transmissionbase.transmissionbaseid = " + myAttribute.value + " and ";
                case "TransmissionType": return "transmissiontypeid = " + myAttribute.value + " and ";
                case "TransmissionControlType": return "transmissioncontroltypeid = " + myAttribute.value + " and ";
                case "TransmissionNumSpeeds": return "transmissionnumspeedsid = " + myAttribute.value + " and ";
                case "TransmissionMfr": return "mfrid = " + myAttribute.value + " and ";
                case "BedLength": return "bedlengthid = " + myAttribute.value + " and ";
                case "BedType": return "bedtypeid = " + myAttribute.value + " and ";
                case "WheelBase": return "wheelbaseid = " + myAttribute.value + " and ";
                case "BrakeSystem": return "brakesystemid = " + myAttribute.value + " and ";
                case "Region": return "regionid = " + myAttribute.value + " and ";
                case "FrontSpringType": return "frontspringtypeid = " + myAttribute.value + " and ";
                case "RearSpringType": return "rearspringtypeid = " + myAttribute.value + " and ";
                case "SteeringSystem": return "steeringsystemid = " + myAttribute.value + " and ";
                case "SteeringType": return "steeringtypeid = " + myAttribute.value + " and ";
                case "ValvesPerEngine": return "engineconfig.valvesid = " + myAttribute.value + " and ";
                default: return "";
            }
        }


        // determine which system group an attribute is in. this is for determining what tables to join in a validation query for the sake of effeciency
        public int systemGroupOfAttribute(VCdbAttribute myAttribute)
        {
            if (myAttribute.name == "Region") { return 0; }
            if (myAttribute.name == "SubModel") { return 0; }

            if (myAttribute.name == "DriveType") { return 1; }

            if (myAttribute.name == "BrakeABS") { return 2; }
            if (myAttribute.name == "BrakeSystem") { return 2; }
            if (myAttribute.name == "FrontBrakeType") { return 2; }
            if (myAttribute.name == "RearBrakeType") { return 2; }

            if (myAttribute.name == "EngineBase") { return 3; }
            if (myAttribute.name == "EngineVIN") { return 3; }
            if (myAttribute.name == "EngineVersion") { return 3; }
            if (myAttribute.name == "EngineMfr") { return 3; }
            if (myAttribute.name == "EngineDesignation") { return 3; }
            if (myAttribute.name == "FuelDeliverySubType") { return 3; }
            if (myAttribute.name == "FuelDeliveryType") { return 3; }
            if (myAttribute.name == "FuelSystemControlType") { return 3; }
            if (myAttribute.name == "FuelSystemDesign") { return 3; }
            if (myAttribute.name == "Aspiration") { return 3; }
            if (myAttribute.name == "IgnitionSystemType") { return 3; }
            if (myAttribute.name == "ValvesPerEngine") { return 3; }
            if (myAttribute.name == "CylinderHeadType") { return 3; }
            if (myAttribute.name == "FuelType") { return 3; }
            if (myAttribute.name == "PowerOutput") { return 3; } // is this depricated in VCdb recently?

            if (myAttribute.name == "BodyNumDoors") { return 4; }
            if (myAttribute.name == "BodyType") { return 4; }

            if (myAttribute.name == "MfrBodyCode") { return 5; }

            if (myAttribute.name == "TransElecControlled") { return 6; } // is this depricated in VCdb recently?
            if (myAttribute.name == "TransmissionBase") { return 6; }
            if (myAttribute.name == "TransmissionControlType") { return 6; }
            if (myAttribute.name == "TransmissionMfr") { return 6; }
            if (myAttribute.name == "TransmissionMfrCode") { return 6; }
            if (myAttribute.name == "TransmissionNumSpeeds") { return 6; }
            if (myAttribute.name == "TransmissionType") { return 6; }

            if (myAttribute.name == "WheelBase") { return 7; }

            if (myAttribute.name == "SteeringSystem") { return 8; }
            if (myAttribute.name == "SteeringType") { return 8; }

            if (myAttribute.name == "BedLength") { return 9; }
            if (myAttribute.name == "BedType") { return 9; }

            if (myAttribute.name == "FrontSpringType") { return 10; }
            if (myAttribute.name == "RearSpringType") { return 10; }

            if (myAttribute.name == "VehicleType") { return 11; }
            return 12;
        }

        public bool attributeHasUKasOption(int baseVehicleid, string attributeName)
        {
            bool returnValue = false;
            App app = new App();
            VCdbAttribute myVCdbAttribute = new VCdbAttribute();
            int idForUK = -1;

            if (attributeName == "DriveType") { idForUK=4; }
            if (attributeName == "BrakeABS") { idForUK=4; } // 9=N/A
            if (attributeName == "BrakeSystem") { idForUK=4; }
            if (attributeName == "FrontBrakeType") { idForUK=4; }
            if (attributeName == "RearBrakeType") { idForUK=4; }
            if (attributeName == "EngineVersion") { idForUK=50; }//2=N/A, 3=N/R
            if (attributeName == "EngineMfr") { idForUK=4; }//2=N/A, 3=N/R
            if (attributeName == "FuelDeliverySubType") { idForUK = 4; }//2=N/A, 3=N/R
            if (attributeName == "FuelSystemControlType") { idForUK = 4; }//2=N/A, 3=N/R
            if (attributeName == "FuelSystemDesign") { idForUK = 4; }//2=N/A, 3=N/R
            if (attributeName == "IgnitionSystemType") { idForUK = 4; }//2=N/A, 3=N/R
            if (attributeName == "ValvesPerEngine") { idForUK = 16; }//17=N/R, 25=N/A
            if (attributeName == "CylinderHeadType") { idForUK = 4; }//2=N/A, 3=N/R
            if (attributeName == "FuelType") { idForUK = 18; }//20=N/A
            if (attributeName == "BodyNumDoors") { idForUK = 4; }
            if (attributeName == "BodyType") { idForUK = 40; }
            if (attributeName == "MfrBodyCode") { idForUK = 4; }//2=N/A, 3=N/R
            if (attributeName == "TransmissionControlType") { idForUK = 4; }//3=N/R
            if (attributeName == "TransmissionMfr") { idForUK = 4; }//2=N/A, 3=N/R
            if (attributeName == "TransmissionMfrCode") { idForUK = 4; }//2=N/A, 3=N/R
            if (attributeName == "TransmissionNumSpeeds") { idForUK = 4; }//2=N/A, 3=N/R
            if (attributeName == "TransmissionType") { idForUK = 4; }//7=N/A, 3=N/R
            if (attributeName == "WheelBase") { idForUK = 4; }//2=N/A
            if (attributeName == "SteeringSystem") { idForUK = 4; }//2=N/A
            if (attributeName == "SteeringType") { idForUK = 4; }//2=N/A
            if (attributeName == "BedLength") { idForUK = 42; }//2=N/A, 3=N/R
            if (attributeName == "BedType") { idForUK = 14; }//2=N/A, 3=N/R
            if (attributeName == "FrontSpringType") { idForUK = 4; }//2=N/A
            if (attributeName == "RearSpringType") { idForUK = 4; }//2=N/A

            if (idForUK == -1) { return false; }
            myVCdbAttribute.name = attributeName;
            myVCdbAttribute.value = idForUK;

            app.basevehilceid = baseVehicleid;
            app.VCdbAttributes.Add(myVCdbAttribute);

            string sqlString = configValidationSQLForApp(app);

            try
            {
                OleDbCommand command = new OleDbCommand(sqlString, vcdbConnection);
                OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {// got a configuration hit on a "U/K" option
                    returnValue = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(sqlString);
            }
            return returnValue;
        }




        public string import()
        {
            clear();
            int i;
            OleDbCommand command = new OleDbCommand("SELECT BaseVehicle.BaseVehicleId,Make.MakeName,Model.ModelName,BaseVehicle.YearId FROM BaseVehicle,Make,Model where BaseVehicle.MakeId=Make.MakeId and BaseVehicle.ModelId=Model.ModelId order by MakeName,ModelName,YearId;");
            command.Connection = vcdbConnection;

            try
            {

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    i = Convert.ToInt32(reader.GetValue(0).ToString());
                    BaseVehicle basevidTemp = new BaseVehicle();
                    basevidTemp.MakeName = reader.GetValue(1).ToString();
                    basevidTemp.ModelName = reader.GetValue(2).ToString();
                    basevidTemp.YearId = reader.GetValue(3).ToString();
                    basevid.Add(i, basevidTemp);
                }
                reader.Close();




                command.CommandText = "SELECT versiondate from version;"; reader = command.ExecuteReader();
                while (reader.Read()) { version = reader.GetValue(0).ToString(); }

                DateTime dt = new DateTime();
                if ( DateTime.TryParseExact(version, "M/d/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt)){ version = dt.ToString("yyyy-MM-dd"); }
                reader.Close();

                command.CommandText = "SELECT enginebaseid,liter,cc,cid,cylinders,blocktype from enginebase;"; reader = command.ExecuteReader();
                while (reader.Read()) { i = Convert.ToInt32(reader.GetValue(0).ToString()); enginebase.Add(i, reader.GetValue(5).ToString().Trim() + reader.GetValue(4).ToString().Trim() + " " + reader.GetValue(1).ToString().Trim() + "L"); }
                reader.Close();

                command.CommandText = "SELECT submodelid,submodelname from submodel"; reader = command.ExecuteReader();
                while (reader.Read()) { i = Convert.ToInt32(reader.GetValue(0).ToString()); submodel.Add(i, reader.GetValue(1).ToString()); }
                reader.Close();

                command.CommandText = "SELECT drivetypeid,drivetypename from drivetype;"; reader = command.ExecuteReader();
                while (reader.Read()) { i = Convert.ToInt32(reader.GetValue(0).ToString()); drivetype.Add(i, reader.GetValue(1).ToString()); }
                reader.Close();

                command.CommandText = "SELECT aspirationid,aspirationname from aspiration;"; reader = command.ExecuteReader();
                while (reader.Read()) { i = Convert.ToInt32(reader.GetValue(0).ToString()); aspiration.Add(i, reader.GetValue(1).ToString()); }
                reader.Close();

                command.CommandText = "SELECT fueltypeid,fueltypename from fueltype;"; reader = command.ExecuteReader();
                while (reader.Read()) { i = Convert.ToInt32(reader.GetValue(0).ToString()); fueltype.Add(i, reader.GetValue(1).ToString()); }
                reader.Close();

                command.CommandText = "SELECT braketypeid,braketypename from braketype;"; reader = command.ExecuteReader();
                while (reader.Read()) { i = Convert.ToInt32(reader.GetValue(0).ToString()); braketype.Add(i, reader.GetValue(1).ToString()); }
                reader.Close();

                command.CommandText = "SELECT brakeabsid,brakeabsname from brakeabs;"; reader = command.ExecuteReader();
                while (reader.Read()) { i = Convert.ToInt32(reader.GetValue(0).ToString()); brakeabs.Add(i, reader.GetValue(1).ToString()); }
                reader.Close();

                command.CommandText = "SELECT mfrbodycodeid,mfrbodycodename from mfrbodycode;"; reader = command.ExecuteReader();
                while (reader.Read()) { i = Convert.ToInt32(reader.GetValue(0).ToString()); mfrbodycode.Add(i, reader.GetValue(1).ToString()); }
                reader.Close();

                command.CommandText = "SELECT bodynumdoorsid,bodynumdoors from bodynumdoors;"; reader = command.ExecuteReader();
                while (reader.Read()) { i = Convert.ToInt32(reader.GetValue(0).ToString()); bodynumdoors.Add(i, reader.GetValue(1).ToString()); }
                reader.Close();

                command.CommandText = "SELECT bodytypeid,bodytypename from bodytype;"; reader = command.ExecuteReader();
                while (reader.Read()) { i = Convert.ToInt32(reader.GetValue(0).ToString()); bodytype.Add(i, reader.GetValue(1).ToString()); }
                reader.Close();

                command.CommandText = "SELECT enginedesignationid,enginedesignationname from enginedesignation;"; reader = command.ExecuteReader();
                while (reader.Read()) { i = Convert.ToInt32(reader.GetValue(0).ToString()); enginedesignation.Add(i, reader.GetValue(1).ToString()); }
                reader.Close();

                command.CommandText = "SELECT enginevinid,enginevinname from enginevin;"; reader = command.ExecuteReader();
                while (reader.Read()) { i = Convert.ToInt32(reader.GetValue(0).ToString()); enginevin.Add(i, reader.GetValue(1).ToString()); }
                reader.Close();

                command.CommandText = "SELECT engineversionid,engineversion from engineversion;"; reader = command.ExecuteReader();
                while (reader.Read()) { i = Convert.ToInt32(reader.GetValue(0).ToString()); engineversion.Add(i, reader.GetValue(1).ToString()); }
                reader.Close();

                command.CommandText = "SELECT mfrid,mfrname from mfr;"; reader = command.ExecuteReader();
                while (reader.Read()) { i = Convert.ToInt32(reader.GetValue(0).ToString()); mfr.Add(i, reader.GetValue(1).ToString()); }
                reader.Close();

                command.CommandText = "SELECT fueldeliverytypeid,fueldeliverytypename from fueldeliverytype;"; reader = command.ExecuteReader();
                while (reader.Read()) { i = Convert.ToInt32(reader.GetValue(0).ToString()); fueldeliverytype.Add(i, reader.GetValue(1).ToString()); }
                reader.Close();

                command.CommandText = "SELECT fueldeliverysubtypeid,fueldeliverysubtypename from fueldeliverysubtype;"; reader = command.ExecuteReader();
                while (reader.Read()) { i = Convert.ToInt32(reader.GetValue(0).ToString()); fueldeliverysubtype.Add(i, reader.GetValue(1).ToString()); }
                reader.Close();

                command.CommandText = "SELECT fuelsystemcontroltypeid,fuelsystemcontroltypename from fuelsystemcontroltype;"; reader = command.ExecuteReader();
                while (reader.Read()) { i = Convert.ToInt32(reader.GetValue(0).ToString()); fuelsystemcontroltype.Add(i, reader.GetValue(1).ToString()); }
                reader.Close();

                command.CommandText = "SELECT fuelsystemdesignid,fuelsystemdesignname from fuelsystemdesign;"; reader = command.ExecuteReader();
                while (reader.Read()) { i = Convert.ToInt32(reader.GetValue(0).ToString()); fuelsystemdesign.Add(i, reader.GetValue(1).ToString()); }
                reader.Close();

                command.CommandText = "SELECT cylinderheadtypeid,cylinderheadtypename from cylinderheadtype;"; reader = command.ExecuteReader();
                while (reader.Read()) { i = Convert.ToInt32(reader.GetValue(0).ToString()); cylinderheadtype.Add(i, reader.GetValue(1).ToString()); }
                reader.Close();

                command.CommandText = "SELECT ignitionsystemtypeid,ignitionsystemtypename from ignitionsystemtype;"; reader = command.ExecuteReader();
                while (reader.Read()) { i = Convert.ToInt32(reader.GetValue(0).ToString()); ignitionsystemtype.Add(i, reader.GetValue(1).ToString()); }
                reader.Close();

                command.CommandText = "SELECT transmissionmfrcodeid,transmissionmfrcode from transmissionmfrcode;"; reader = command.ExecuteReader();
                while (reader.Read()) { i = Convert.ToInt32(reader.GetValue(0).ToString()); transmissionmfrcode.Add(i, reader.GetValue(1).ToString()); }
                reader.Close();

                command.CommandText = "SELECT transmissionbase.transmissionbaseid,transmissioncontroltypename, transmissiontypename, transmissionnumspeeds from transmissionbase, transmissiontype, transmissionnumspeeds, transmissioncontroltype WHERE transmissionbase.transmissiontypeid = transmissiontype.transmissiontypeid AND transmissionbase.transmissionnumspeedsid = transmissionnumspeeds.transmissionnumspeedsid AND transmissionbase.transmissioncontroltypeid = transmissioncontroltype.transmissioncontroltypeid;"; reader = command.ExecuteReader();
                while (reader.Read()) { i = Convert.ToInt32(reader.GetValue(0).ToString()); transmissionbase.Add(i, reader.GetValue(1).ToString().Trim() + " " + reader.GetValue(2).ToString().Trim() + " Speed " + reader.GetValue(3).ToString().Trim()); }
                reader.Close();

                command.CommandText = "SELECT transmissiontypeid,transmissiontypename from transmissiontype;"; reader = command.ExecuteReader();
                while (reader.Read()) { i = Convert.ToInt32(reader.GetValue(0).ToString()); transmissiontype.Add(i, reader.GetValue(1).ToString()); }
                reader.Close();

                command.CommandText = "SELECT transmissioncontroltypeid,transmissioncontroltypename from transmissioncontroltype;"; reader = command.ExecuteReader();
                while (reader.Read()) { i = Convert.ToInt32(reader.GetValue(0).ToString()); transmissioncontroltype.Add(i, reader.GetValue(1).ToString()); }
                reader.Close();

                command.CommandText = "SELECT transmissionnumspeedsid,transmissionnumspeeds from transmissionnumspeeds;"; reader = command.ExecuteReader();
                while (reader.Read()) { i = Convert.ToInt32(reader.GetValue(0).ToString()); transmissionnumspeeds.Add(i, reader.GetValue(1).ToString()); }
                reader.Close();

                command.CommandText = "SELECT bedlengthid,bedlength from bedlength;"; reader = command.ExecuteReader();
                while (reader.Read()) { i = Convert.ToInt32(reader.GetValue(0).ToString()); bedlength.Add(i, reader.GetValue(1).ToString()); }
                reader.Close();

                command.CommandText = "SELECT bedtypeid,bedtypename from bedtype;"; reader = command.ExecuteReader();
                while (reader.Read()) { i = Convert.ToInt32(reader.GetValue(0).ToString()); bedtype.Add(i, reader.GetValue(1).ToString()); }
                reader.Close();

                command.CommandText = "SELECT wheelbaseid,wheelbase from wheelbase;"; reader = command.ExecuteReader();
                while (reader.Read()) { i = Convert.ToInt32(reader.GetValue(0).ToString()); wheelbase.Add(i, reader.GetValue(1).ToString()); }
                reader.Close();

                command.CommandText = "SELECT brakesystemid,brakesystemname from brakesystem;"; reader = command.ExecuteReader();
                while (reader.Read()) { i = Convert.ToInt32(reader.GetValue(0).ToString()); brakesystem.Add(i, reader.GetValue(1).ToString()); }
                reader.Close();

                command.CommandText = "SELECT regionid,regionname from region;"; reader = command.ExecuteReader();
                while (reader.Read()) { i = Convert.ToInt32(reader.GetValue(0).ToString()); region.Add(i, reader.GetValue(1).ToString()); }
                reader.Close();

                command.CommandText = "SELECT springtypeid,springtypename from springtype;"; reader = command.ExecuteReader();
                while (reader.Read()) { i = Convert.ToInt32(reader.GetValue(0).ToString()); springtype.Add(i, reader.GetValue(1).ToString()); }
                reader.Close();

                command.CommandText = "SELECT steeringsystemid,steeringsystemname from steeringsystem;"; reader = command.ExecuteReader();
                while (reader.Read()) { i = Convert.ToInt32(reader.GetValue(0).ToString()); steeringsystem.Add(i, reader.GetValue(1).ToString()); }
                reader.Close();

                command.CommandText = "SELECT steeringtypeid,steeringtypename from steeringtype;"; reader = command.ExecuteReader();
                while (reader.Read()) { i = Convert.ToInt32(reader.GetValue(0).ToString()); steeringtype.Add(i, reader.GetValue(1).ToString()); }
                reader.Close();

                command.CommandText = "SELECT valvesid,valvesperengine from valves;"; reader = command.ExecuteReader();
                while (reader.Read()) { i = Convert.ToInt32(reader.GetValue(0).ToString()); valves.Add(i, reader.GetValue(1).ToString()); }
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
            return "";
        }
    }





    public class PCdb
    {
        public OleDbConnection pcdbConnection = new OleDbConnection();
        public string filePath = "";
        public string version = "";

        // the fundemental elements of the PCdb are loaded into hash tables ("Dictionaries") for the sake of speed.
        // there is about a 3x speed advandage of doing code validation against in-memory hash tables vs. querying the database
        // the memory cost is trivial. At database load time, a query is executed for each dictionary.

        public Dictionary<int, String> parttypes = new Dictionary<int, string>();
        public Dictionary<int, String> positions = new Dictionary<int, string>();
        public List<string> codmasterParttypePoisitions = new List<string>();


        public string import()
        {
            clear();
            int i;
            OleDbCommand command = new OleDbCommand("select versiondate from version;");
            command.Connection = pcdbConnection;
            try
            {
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read()) { version = reader.GetValue(0).ToString(); }
                reader.Close();

                DateTime dt = new DateTime(); if (DateTime.TryParseExact(version, "M/d/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt)) { version = dt.ToString("yyyy-MM-dd"); }

                //prebake all the parttype/name relationships into a hashtable ("Dictionary")
                command.CommandText = "select partterminologyid,partterminologyname from parts;"; reader = command.ExecuteReader();
                while (reader.Read()) { i = Convert.ToInt32(reader.GetValue(0).ToString()); parttypes.Add(i, reader.GetValue(1).ToString()); }
                reader.Close();

                //prebake all the position/name relationships into a hashtable ("Dictionary")
                command.CommandText = "select * from positions;"; reader = command.ExecuteReader();
                while (reader.Read()) { i = Convert.ToInt32(reader.GetValue(0).ToString()); positions.Add(i, reader.GetValue(1).ToString()); }
                reader.Close();

                // make a composite key string in a List<string> to store all valid combinations of parttype/position from the codemaster table of the pcdb.
                // the ".contains" method can then be run on the list for app validation - this avoids having to query the codemast table for every app
                // speed gain was roughly 100x
                command.CommandText = "select partterminologyid, positionid from codemaster;"; reader = command.ExecuteReader();
                while (reader.Read()){codmasterParttypePoisitions.Add(Convert.ToInt32(reader.GetValue(0).ToString()) + "_" + Convert.ToInt32(reader.GetValue(1).ToString()));}
                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
            return "";
        }



        public void connect(string _filePath)
        {
            filePath = _filePath;
            if (pcdbConnection.State == System.Data.ConnectionState.Closed)
            {
                pcdbConnection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + _filePath;
                pcdbConnection.Open();
            }
        }

        public void disconnect()
        {
            filePath = "";
            if (pcdbConnection.State != System.Data.ConnectionState.Closed)
            {
                pcdbConnection.Close();
            }
        }

        public void clear()
        {
            filePath = "";
            version = "";
            parttypes.Clear();
            positions.Clear();
        }

        public string niceParttype(int parttypeid)
        {
            string niceValue = "";
            if(parttypes.TryGetValue(parttypeid, out niceValue)){ return niceValue; }
            return parttypeid.ToString(); 
        }


        public string nicePosition(int positionid)
        {
            string niceValue = "";
            if(positions.TryGetValue(positionid, out niceValue)){ return niceValue; }
            return positionid.ToString();
        }



    }

    
}
