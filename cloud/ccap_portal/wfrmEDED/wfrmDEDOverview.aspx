<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wfrmDEDOverview.aspx.cs" Inherits="wfrmEDED_wfrmDEDOverview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
 <h2 style="color:#66ccff">
       CCAP - Formerly OPIIS - Online Data Element Dictionary
    </h2>
    <h4  style="color:#66ccff"><b>Introduction</b></h4>
    <p>
       Welcome to the CCAP Data Element Dictionary
        <br />This document presents a description of the data contained in the CCAP data mart. This document provides a 
            comprehensive source of documentation for all data contained in the data mart, including the organizational structure of the data within the 
            data mart as well as business definitions for each column.
        
        </p>
        <h4 style="color:#66ccff"><b>Purpose</b></h4>
        <p>
        <br />The purpose of this document is to provide direct-access data users with a comprehensive resource for understanding the data found in the CCAP data mart. 
        The data element dictionary (DED) provides definitions and descriptions for each column found in the OPIIS 2.0 data mart. 
        As users make use of the data found in the data mart, they can refer to the DED to ensure that they are using and interpreting the data correctly.
        </p>
        <h4 style="color:#66ccff"><b>Scope</b></h4>
        <p>
        <br />The purpose of this document is to provide direct-access data users with a comprehensive resource for understanding the data found in the CCAP data mart. 
        The data element dictionary (DED) provides definitions and descriptions for each column found in the CCAP data mart. 
        As users make use of the data found in the data mart, they can refer to the DED to ensure that they are using and interpreting the data correctly.
        </p>

         </p>
        <h4 style="color:#66ccff"><b>System Overview</b></h4>
        <p>
        <br />
        The CCAP data mart is a consolidated source of data compiled from HUD’s various multifamily systems. The CCAP data mart includes property-specific information related to loans, 
        grants, assistance contracts, and annual financial statements, among other things. Sources of the data within the CCAPdata mart include the Financial Assessment
        Subsystem (FASS), Physical Assessment Subsystem (PASS), Real Estate Management System (REMS), Development Application 
        Processing (DAP) System, and multifamily data from external sources.
        </p>
   
     <h4 style="color:#66ccff"><b>Data Mart Tables</b></h4>
        <p>
        <br />
     The OPIIS 2.0 data mart contains five types of tables: primary reporting tables, secondary reporting tables, history tables, reference tables, and utility tables.
      Figure 1 contains a comprehensive list of tables by table type found in the data mart. Each type is described in the following sections
        </p>


         <h4 style="color:#66ccff"><b>Primary Reporting Tables</b></h4>
        <p>
        <br />
       Primary reporting tables contain characteristics relating to people, places, things, or events. 
       The data in primary tables has value independent of other primary tables, and the data in primary tables may change frequently.
     
        <br />
      The primary reporting tables in the OPIIS 2.0 data mart will be used regularly by most users. In general, these tables contain the most 
      commonly used high-level fact data associated with a particular entity (e.g., property, contract, AFS, disposition, inspection, use restriction, etc.).
        </p>

         <h4 style="color:#66ccff"><b>Secondary Reporting Tables</b></h4>
        <p>
        <br />
       Secondary reporting tables contain detail-level data that is dependent upon a primary parent table for meaning. 
       Secondary tables may have one or more records for each record in their parent tables.
    
        <br />
       The secondary reporting tables in the OPIIS 2.0 data mart include all of the annual financial statement (AFS) child tables. Each of these tables includes an AFS Id, Header Id, Project Id, and differing numbers of tags, metrics, and dates. These tables are dependent on primary AFS reporting tables. An AFS Id cannot exist in a child table without existing in a primary AFS table. 
       The contents of each table are based on the account drill path documentation provided by the FASS team.
     
        <br />
       The data in the secondary reporting tables is stored at a more granular level than the data contained in the primary AFS reporting tables. It is important to note that the consistency 
       and validity of the data in these secondary tables is completely dependent upon the data found in the source system (FASS).
        </p>

         <h4 style="color:#66ccff"><b>History Tables</b></h4>
        <p>
        <br />
       History tables store data to track a sequence of actions or data changes. 
       History tables may shadow one or more primary tables and record when changes are made to the data in those primary tables.
       <br />
       The OPIIS 2.0 data mart includes five history tables. Each history table contains a running history of a specific type of data associated with a property. For example, the mf_history_property_active table contains a history of the active/inactive status for each property 
       in the data mart. Each time the active status for a property changes, a new record is added to this table.
        </p>


          <h4 style="color:#66ccff"><b>Reference Tables</b></h4>
        <p>
        <br />
      Reference tables contain data that only exists to characterize data in other tables. The data in reference tables usually changes infrequently.
             <br />
       There are approximately 80 reference tables in the OPIIS 2.0 data mart. These tables, also known as lookup tables, are provided as a means of looking up related information across multiple reporting tables. The reference tables typically consist of a primary key column as well as some sort of characteristic. 
       The primary keys can be used to link the reference table to a reporting table containing the same column as a foreign key.
        <br />
        </p>
         <h4 style="color:#66ccff"><b>Data Element Dictionary Organization</b></h4>

        <p>
         <br />
         The contents of the data element dictionary are organized alphabetically by table name. For each
table in the data mart, the documentation provides the table name and a brief description of the table contents followed by a detailed list of all
columns in the table with the business name, physical name, data type, nulls-allowed indicator, and business definition for each. The columns are organized in the same order that they appear in the data mart. This column ordering convention organizes columns alphabetically within each data class, with the data classes in the following order: primary keys (data fields beginning with pk), foreign keys (fk, sequences)

        </p>

         <h4 style="color:#66ccff"><b>Business Column Name</b></h4>

        <p>
        The business column name is simply the physical name translated into full words. In many cases, the business column name is almost identical to the physical name. This is because the physical names selected for the data mart were intended to be as descriptive as possible, using very few abbreviations and only using acronyms that are commonly used within HUD.
         <br />
         </p>
 
   <h4 style="color:#66ccff"><b>Physical Name</b></h4>

        <p>
        The physical name is the exact name of the column as seen in the data mart. This name follows the column naming convention outlined in “Table and Column Convention Options for OPIIS 2.0 Data Mart” dated November 9, 2007. For further information regarding the physical names in the data mart, please refer to this document.
  <br />
         </p>

          <h4 style="color:#66ccff"><b>Data Type</b></h4>

        <p>
       The data type identifies the format in which the data in each column is stored. Given that the OPIIS 2.0 data mart is a compilation of data from other multifamily data sources, many of the data types are dependent upon the data types in the source systems. When the data is pulled from the various source systems, the most appropriate data type is automatically identified based on the data found in the column, unless otherwise specified in the data extraction process.
<br/>The data type column for each documented table includes both the data type and the precision of the data stored in a given table and column, where appropriate. The precision component applies to character, variable character, and decimal data types and consists of one or two numbers in parentheses. When there is one number only, this number represents the maximum number of characters allowed. When there are two numbers separated by a comma, the first number identifies the total length of the data, while the second number identifies the number of places to the right of the decimal place. For example, a precision of (255) indicates that the column can store a maximum of 255 characters. The precision of (8,2) indicates that the column contains decimals that are 10 total numbers in length, with eight numbers to the left of the decimal place and two numbers to the right of the decimal place.
<br/>In most cases, the data types are documented exactly as they are stored in the data mart. However, for numeric and decimal data types, which are essentially identical, the documentation refers to a data type of decimal for both.
  <br />
         </p>

   <h4 style="color:#66ccff"><b>Definition</b></h4>

        <p>
      The definition column for each documented table contains a business definition for each column in the table. The business definition is intended to provide OPIIS 2.0 data mart users with information regarding the actual contents of a column to help users utilize and interpret the data correctly. In many cases, the definition also identifies the original source of the data in a column.
  <br />
         </p>



          <p>
        Click here to see a list of the tables in the CCAP Data Mart  <asp:HyperLink  ID="HyperLink1"  runat="server"  Text="View List of Tables"   NavigateUrl="~/wfrmEDED/wfrmTableUpdateFrequencies.aspx"> View List of Tables</asp:HyperLink>.
    </p>
    <p>
        To learn more about Commercial Capital Assessment Projections visit <a href="http://hudatwork.hud.gov/HUD/housing/po/h/rmra/oe/opiis20/opiismenu20" title="CCAP/OPIIS Website">CCAP</a>.
    </p>
    <p>
        You can also find information on the Office of Housings <a href="http://hudatwork.hud.gov/HUD/housing/po/h/rmra/oe/opiis20/opiismenu20"
            title="HUD Information ">Office of Risk Management & Regulatory Affairs </a>.
    </p>
</asp:Content>

