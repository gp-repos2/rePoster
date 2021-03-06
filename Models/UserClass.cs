using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ConnectLib;
using System.Windows.Forms;

namespace rePoster.Models
{
    class UserItem
    {
      /*  private string _DBID;
        private bool? _automated;
        private string _keyID;
        private PostItem _post;
        private int _accessID;
        private int? _licTypeID;
        private DepartmentItem _department;
        private string _gender;
        private string _note;
        private string _SID;
        private string _phone;
        private string _tabNum;
        private string _eMail;
        private string _house;
        private int? _statusID;*/

        private int id;
        private string userName; 
        private string firstName;
        private string lastName;
        private string login;

        /*private string Email;
        private string Gender;
        private DateTime BirthDate;
        private string Avatar;
        private string Country;
        private string City;
        private DateTime RegDate;*/

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string UserName
        {
            get { return userName != null ? userName : ""; }
            set { userName = value; }
        }

        public string FirstName
        {
            get { return firstName != null ? firstName : ""; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName != null ? lastName : ""; }
            set { lastName = value; }
        }

        public string Login
        {
            get { return login != null ? login : ""; }
            set { login = value; }
        }

        /*
        public bool? Automated
        {
            get { return _automated != null ? _automated : false; }
            set { _automated = value; }
        }

        public string KeyID
        {
            get { return _keyID != null ? _keyID : ""; }
            set { _keyID = value; }
        }

        public PostItem Post
        {
            get { return _post; }
            set { _post = value; }
        }

        public int AccessID
        {
            get { return _accessID; }
            set { _accessID = value; }
        }

        public int? LicTypeID
        {
            get { return _licTypeID != null ? _licTypeID : 0; }
            set { _licTypeID = value; }
        }

        public DepartmentItem Department
        {
            get { return _department; }
            set { _department = value; }
        }


        public string Note
        {
            get { return _note != null ? _note : ""; }
            set { _note = value; }
        }

        public string SID
        {
            get { return _SID != null ? _SID : ""; }
            set { _SID = value; }
        }

        public string Phone
        {
            get { return _phone != null ? _phone : ""; }
            set { _phone = value; }
        }

        public string TabNum
        {
            get { return _tabNum != null ? _tabNum : ""; }
            set { _tabNum = value; }
        }

        public string EMail
        {
            get { return _eMail != null ? _eMail : ""; }
            set { _eMail = value; }
        }

        public string House
        {
            get { return _house != null ? _house : ""; }
            set { _house = value; }
        }

        public int? StatusID
        {
            get { return _statusID != null ? _statusID : 0; }
            set { _statusID = value; }
        }
        */
        public int ObjectType()
        {
            return 1;
        }

        public UserItem(int UserID)
        {
        }

        public DataTable GetDataTable(sqlConnectClass sqlConnect)
        {
            return sqlConnect.GetData("SELECT TOP U.[ID],U.[UserName],U.[FirstName],U.[LastName],U.[Login] FROM [dbo].[UniUser] AS U.[ID]=" + ID);
        }

        public void LoadData(sqlConnectClass sqlConnect)
        {
            DataTable DT = GetDataTable(sqlConnect);
            if (DT.Rows.Count == 1)
            {
                id = Convert.ToInt32(DT.Rows[0]["ID"]);
                userName = DT.Rows[0]["UserName"].ToString();
                firstName = (DT.Rows[0]["FirstName"] != DBNull.Value) ? DT.Rows[0]["FirstName"].ToString() : (string)null;
                lastName = (DT.Rows[0]["LastName"] != DBNull.Value) ? DT.Rows[0]["LastName"].ToString() : (string)null;
                login = (DT.Rows[0]["Login"] != DBNull.Value) ? DT.Rows[0]["Login"].ToString() : (string)null;

               /* _automated = (DT.Rows[0]["Automated"] != DBNull.Value) ? (DT.Rows[0]["Automated"].ToString() == "+") : (bool?)null;
                _keyID = (DT.Rows[0]["KeyID"] != DBNull.Value) ? DT.Rows[0]["KeyID"].ToString() : (string)null;
                if (DT.Rows[0]["PostID"] != DBNull.Value)
                    _post  = new PostItem(Convert.ToInt32(DT.Rows[0]["PostID"]));
                _accessID = Convert.ToInt32(DT.Rows[0]["AccessID"]);
                _licTypeID = (DT.Rows[0]["LicTypeID"] != DBNull.Value) ? Convert.ToInt32(DT.Rows[0]["LicTypeID"]) : (int?)null;
                if (DT.Rows[0]["DepartmentID"] != DBNull.Value)
                    _department  = new DepartmentItem(Convert.ToInt32(DT.Rows[0]["DepartmentID"]));
                _gender = (DT.Rows[0]["Gender"] != DBNull.Value) ? DT.Rows[0]["Gender"].ToString() : (string)null;
                _note = (DT.Rows[0]["Note"] != DBNull.Value) ? DT.Rows[0]["Note"].ToString() : (string)null;
                _SID = (DT.Rows[0]["SID"] != DBNull.Value) ? DT.Rows[0]["SID"].ToString() : (string)null;
                _phone = (DT.Rows[0]["Phone"] != DBNull.Value) ? DT.Rows[0]["Phone"].ToString() : (string)null;
                _tabNum = (DT.Rows[0]["TabNum"] != DBNull.Value) ? DT.Rows[0]["TabNum"].ToString() : (string)null;
                _eMail = (DT.Rows[0]["EMail"] != DBNull.Value) ? DT.Rows[0]["EMail"].ToString() : (string)null;
                _house = (DT.Rows[0]["House"] != DBNull.Value) ? DT.Rows[0]["House"].ToString() : (string)null;
                _statusID = (DT.Rows[0]["StatusID"] != DBNull.Value) ? Convert.ToInt32(DT.Rows[0]["StatusID"]) : (int?)null;
                IsAutomated = (DT.Rows[0]["IsAutomated"] != DBNull.Value) ? (DT.Rows[0]["IsAutomated"].ToString() == "+") : (bool?)null;
                IsLocked = (DT.Rows[0]["IsLocked"] != DBNull.Value) ? (DT.Rows[0]["IsLocked"].ToString() == "+") : (bool?)null;
                Name = (DT.Rows[0]["Name"] != DBNull.Value) ? DT.Rows[0]["Name"].ToString() : (string)null;
                ShortName = (DT.Rows[0]["ShortName"] != DBNull.Value) ? DT.Rows[0]["ShortName"].ToString() : (string)null;
                AddIndex = (DT.Rows[0]["AddIndex"] != DBNull.Value) ? DT.Rows[0]["AddIndex"].ToString() : (string)null;
                if (DT.Rows[0]["ParentID"] != DBNull.Value)
                    Parent  = new VocabularyItem(Convert.ToInt32(DT.Rows[0]["ParentID"]));
                Actual = (DT.Rows[0]["Actual"].ToString() == "+");*/
            }
        }

        public void LoadLinkedData(sqlConnectClass sqlConnect)
        {
          /* if (_department != null)
                _department.LoadData(sqlConnect);
            if (_post != null)
                _post.LoadData(sqlConnect);
            if (Parent != null)
                Parent.LoadData(sqlConnect);*/
        }

        public void SaveData(sqlConnectClass sqlConnect, bool AllowInsert, bool SilentMode)
        {
            DataTable DT = sqlConnect.GetData("SELECT 1 FROM [dbo].[UniUser] WHERE [ID]=" + ID.ToString());
            if (DT.Rows.Count == 1)
            {
                UpdateData(sqlConnect);
                //base.SaveData(sqlConnect, AllowInsert, SilentMode);
            }
            else if (AllowInsert)
            {
                //base.SaveData(sqlConnect, AllowInsert, SilentMode);
                InsertData(sqlConnect, SilentMode);
            }
        }

        public void SaveData(sqlConnectClass sqlConnect, bool AllowInsert)
        {
            SaveData(sqlConnect, AllowInsert, false);
        }

        private void UpdateData(sqlConnectClass sqlConnect)
        {
            if (ID == 0) return;

            sqlConnect.InitScript();
            sqlConnect.AddScript("UPDATE [dbo].[LDUSER]");
            sqlConnect.AddScript("SET [DBID]=" + (_DBID != null ? "'" + _DBID + "'" : "NULL"));
            sqlConnect.AddScript(",[Automated]='" + ((_automated != null ? (bool)_automated : false) ? "+" : "-") + "'");
            sqlConnect.AddScript(",[KeyID]=" + (_keyID != null ? "'" + _keyID + "'" : "NULL"));
            sqlConnect.AddScript(",[PostID]=" + (_post != null ? _post.ID.ToString() : "NULL"));
            sqlConnect.AddScript(",[AccessID]=" + _accessID.ToString());
            sqlConnect.AddScript(",[LicTypeID]=" + (_licTypeID != null ? _licTypeID.ToString() : "NULL"));
            sqlConnect.AddScript(",[DepartmentID]=" + (_department != null ? _department.ID.ToString() : "NULL"));
            sqlConnect.AddScript(",[Gender]=" + (_gender != null ? "'" + _gender + "'" : "NULL"));
            sqlConnect.AddScript(",[Note]=" + (_note != null ? "'" + _note + "'" : "NULL"));
            sqlConnect.AddScript(",[SID]=" + (_SID != null ? "'" + _SID + "'" : "NULL"));
            sqlConnect.AddScript(",[Phone]=" + (_phone != null ? "'" + _phone + "'" : "NULL"));
            sqlConnect.AddScript(",[TabNum]=" + (_tabNum != null ? "'" + _tabNum + "'" : "NULL"));
            sqlConnect.AddScript(",[EMail]=" + (_eMail != null ? "'" + _eMail + "'" : "NULL"));
            sqlConnect.AddScript(",[House]=" + (_house != null ? "'" + _house + "'" : "NULL"));
            sqlConnect.AddScript(",[StatusID]=" + (_statusID != null ? _statusID.ToString() : "NULL"));
            sqlConnect.AddScript("WHERE [ID]=" + ID.ToString());
            sqlConnect.ExecCommand();
        }

        private void InsertData(sqlConnectClass sqlConnect, bool SilentMode)
        {
            if (ID == 0) return;

            sqlConnect.InitScript();
            sqlConnect.AddScript("INSERT INTO [dbo].[LDUSER]");
            List<string> LoadFields = new List<string>();
            if (_DBID != null) LoadFields.Add("[DBID]");
            if (_automated != null) LoadFields.Add("[Automated]");
            if (_keyID != null) LoadFields.Add("[KeyID]");
            if (_post != null) LoadFields.Add("[PostID]");
            LoadFields.Add("[AccessID]");
            if (_licTypeID != null) LoadFields.Add("[LicTypeID]");
            if (_department != null) LoadFields.Add("[DepartmentID]");
            if (_gender != null) LoadFields.Add("[Gender]");
            if (_note != null) LoadFields.Add("[Note]");
            if (_SID != null) LoadFields.Add("[SID]");
            if (_phone != null) LoadFields.Add("[Phone]");
            if (_tabNum != null) LoadFields.Add("[TabNum]");
            if (_eMail != null) LoadFields.Add("[EMail]");
            if (_house != null) LoadFields.Add("[House]");
            if (_statusID != null) LoadFields.Add("[StatusID]");
            LoadFields.Add("[ID]");
            sqlConnect.AddScript("(" + String.Join(",", LoadFields.ToArray()) + ")");
            sqlConnect.AddScript("VALUES");
            LoadFields.Clear();
            if (_DBID != null) LoadFields.Add("'" + _DBID + "'");
            if (_automated != null) LoadFields.Add("'" + ((bool)_automated ? "+" : "-") + "'");
            if (_keyID != null) LoadFields.Add("'" + _keyID + "'");
            if (_post != null) LoadFields.Add(_post.ID.ToString());
            LoadFields.Add(_accessID.ToString());
            if (_licTypeID != null) LoadFields.Add(_licTypeID.ToString());
            if (_department != null) LoadFields.Add(_department.ID.ToString());
            if (_gender != null) LoadFields.Add("'" + _gender + "'");
            if (_note != null) LoadFields.Add("'" + _note + "'");
            if (_SID != null) LoadFields.Add("'" + _SID + "'");
            if (_phone != null) LoadFields.Add("'" + _phone + "'");
            if (_tabNum != null) LoadFields.Add("'" + _tabNum + "'");
            if (_eMail != null) LoadFields.Add("'" + _eMail + "'");
            if (_house != null) LoadFields.Add("'" + _house + "'");
            if (_statusID != null) LoadFields.Add(_statusID.ToString());
            LoadFields.Add(ID.ToString());
            sqlConnect.AddScript("(" + String.Join(",", LoadFields.ToArray()) + ")");
            sqlConnect.ExecCommand();
        }

        public bool DeleteDBRecord(sqlConnectClass sqlConnect)
        {
            if (ID == 0) return false;

            sqlConnect.ExecCommand("DELETE FROM [dbo].[UniUser] WHERE [ID]=" + ID.ToString());

           // base.DeleteDBRecord(sqlConnect);

            return true;
        }

        public DateTime DB_GetDate(sqlConnectClass sqlConnect)
        {
            DataTable DT = sqlConnect.GetData("SELECT GETDATE()");
            return Convert.ToDateTime(DT.Rows[0][0]);
        }

        public Guid DB_NewGUID(sqlConnectClass sqlConnect)
        {
            DataTable DT = sqlConnect.GetData("SELECT NEWID()");
            return (Guid)DT.Rows[0][0];
        }

        public bool isFemale
        {
            get { return ((string)_gender == "F"); }
        }

        public bool isMale
        {
            get { return ((string)_gender == "M"); }
        }

    }


    class UserList
    {
        public List<UserItem> Items;
        private string _strWHERE = "";
        private string _strORDER = "";

        public UserList()
        {

        }

        public UserList(string WHEREStatement)
        {
            _strWHERE = WHEREStatement;
        }

        public UserList(string WHEREStatement, string ORDERStatement)
        {
            _strWHERE = WHEREStatement;
            _strORDER = ORDERStatement;
        }

        public DataTable GetDataTable(sqlConnectClass sqlConnect)
        {
            sqlConnect.InitScript();
            sqlConnect.AddScript("SELECT U.[DBID],U.[Automated],U.[KeyID],U.[PostID],U.[AccessID],U.[LicTypeID],U.[DepartmentID],U.[Gender],U.[Note],U.[SID],U.[Phone],U.[TabNum],U.[EMail],U.[House],U.[StatusID],M.[IsAutomated],M.[IsLocked],V.[ID],V.[Name],V.[ShortName],V.[AddIndex],V.[ParentID],V.[Actual] FROM [dbo].[LDUSER] AS U INNER JOIN [dbo].[LDMEMBER] AS M ON U.[ID]=M.[ID] INNER JOIN [dbo].[LDVOCABULARY] AS V ON M.[ID]=V.[ID]");
            if (_strWHERE != "")
                sqlConnect.AddScript("WHERE " + _strWHERE);
            if (_strORDER != "")
                sqlConnect.AddScript("ORDER BY " + _strORDER);
            return sqlConnect.GetData();
        }

        public void LoadData(sqlConnectClass sqlConnect)
        {
            DataTable DT = GetDataTable(sqlConnect);
            Items = new List<UserItem>();
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                UserItem ui = new UserItem(Convert.ToInt32(DT.Rows[i]["ID"]));
                ui.DBID = (DT.Rows[i]["DBID"] != DBNull.Value) ? DT.Rows[i]["DBID"].ToString() : (string)null;
                ui.Automated = (DT.Rows[i]["Automated"] != DBNull.Value) ? (DT.Rows[i]["Automated"].ToString() == "+") : (bool?)null;
                ui.KeyID = (DT.Rows[i]["KeyID"] != DBNull.Value) ? DT.Rows[i]["KeyID"].ToString() : (string)null;
                if (DT.Rows[i]["PostID"] != DBNull.Value)
                    ui.Post = new PostItem(Convert.ToInt32(DT.Rows[i]["PostID"]));
                ui.AccessID = Convert.ToInt32(DT.Rows[i]["AccessID"]);
                ui.LicTypeID = (DT.Rows[i]["LicTypeID"] != DBNull.Value) ? Convert.ToInt32(DT.Rows[i]["LicTypeID"]) : (int?)null;
                if (DT.Rows[i]["DepartmentID"] != DBNull.Value)
                    ui.Department = new DepartmentItem(Convert.ToInt32(DT.Rows[i]["DepartmentID"]));
                ui.Gender = (DT.Rows[i]["Gender"] != DBNull.Value) ? DT.Rows[i]["Gender"].ToString() : (string)null;
                ui.Note = (DT.Rows[i]["Note"] != DBNull.Value) ? DT.Rows[i]["Note"].ToString() : (string)null;
                ui.SID = (DT.Rows[i]["SID"] != DBNull.Value) ? DT.Rows[i]["SID"].ToString() : (string)null;
                ui.Phone = (DT.Rows[i]["Phone"] != DBNull.Value) ? DT.Rows[i]["Phone"].ToString() : (string)null;
                ui.TabNum = (DT.Rows[i]["TabNum"] != DBNull.Value) ? DT.Rows[i]["TabNum"].ToString() : (string)null;
                ui.EMail = (DT.Rows[i]["EMail"] != DBNull.Value) ? DT.Rows[i]["EMail"].ToString() : (string)null;
                ui.House = (DT.Rows[i]["House"] != DBNull.Value) ? DT.Rows[i]["House"].ToString() : (string)null;
                ui.StatusID = (DT.Rows[i]["StatusID"] != DBNull.Value) ? Convert.ToInt32(DT.Rows[i]["StatusID"]) : (int?)null;
                ui.IsAutomated = (DT.Rows[i]["IsAutomated"] != DBNull.Value) ? (DT.Rows[i]["IsAutomated"].ToString() == "+") : (bool?)null;
                ui.IsLocked = (DT.Rows[i]["IsLocked"] != DBNull.Value) ? (DT.Rows[i]["IsLocked"].ToString() == "+") : (bool?)null;
                ui.Name = (DT.Rows[i]["Name"] != DBNull.Value) ? DT.Rows[i]["Name"].ToString() : (string)null;
                ui.ShortName = (DT.Rows[i]["ShortName"] != DBNull.Value) ? DT.Rows[i]["ShortName"].ToString() : (string)null;
                ui.AddIndex = (DT.Rows[i]["AddIndex"] != DBNull.Value) ? DT.Rows[i]["AddIndex"].ToString() : (string)null;
                if (DT.Rows[i]["ParentID"] != DBNull.Value)
                    ui.Parent = new VocabularyItem(Convert.ToInt32(DT.Rows[i]["ParentID"]));
                ui.Actual = (DT.Rows[i]["Actual"].ToString() == "+");
                Items.Add(ui);
            }
        }

        public void LoadLinkedData(sqlConnectClass sqlConnect)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].Department != null)
                    Items[i].Department.LoadData(sqlConnect);
                if (Items[i].Post != null)
                    Items[i].Post.LoadData(sqlConnect);
                if (Items[i].Parent != null)
                    Items[i].Parent.LoadData(sqlConnect);
            }
        }

        public UserItem FindItem(int UserID)
        {
            return Items.Where(i => i.ID == UserID).FirstOrDefault();
        }

        public UserItem GetItemByName(string UserName)
        {
            return Items.Where(i => i.Name == UserName).FirstOrDefault();
        }

        public UserItem GetItemByShortName(string UserShortName)
        {
            return Items.Where(i => i.ShortName == UserShortName).FirstOrDefault();
        }

        public UserItem GetItemByAddIndex(string UserAddIndex)
        {
            return Items.Where(i => i.AddIndex == UserAddIndex).FirstOrDefault();
        }

    }

}
