


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SubSonic.DataProviders;
using SubSonic.Extensions;
using System.Linq.Expressions;
using SubSonic.Schema;
using System.Collections;
using SubSonic;
using SubSonic.Repository;
using System.ComponentModel;
using System.Data.Common;

namespace Northwind.Data
{
    
    
    /// <summary>
    /// A class which represents the categories table in the Northwind Database.
    /// </summary>
    public partial class category: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<category> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<category>(new Northwind.Data.NorthwindDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<category> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(category item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                category item=new category();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<category> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Northwind.Data.NorthwindDB _db;
        public category(string connectionString, string providerName) {

            _db=new Northwind.Data.NorthwindDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                category.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<category>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public category(){
             _db=new Northwind.Data.NorthwindDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public category(Expression<Func<category, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<category> GetRepo(string connectionString, string providerName){
            Northwind.Data.NorthwindDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Northwind.Data.NorthwindDB();
            }else{
                db=new Northwind.Data.NorthwindDB(connectionString, providerName);
            }
            IRepository<category> _repo;
            
            if(db.TestMode){
                category.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<category>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<category> GetRepo(){
            return GetRepo("","");
        }
        
        public static category SingleOrDefault(Expression<Func<category, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            category single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static category SingleOrDefault(Expression<Func<category, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            category single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<category, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<category, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<category> Find(Expression<Func<category, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<category> Find(Expression<Func<category, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<category> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<category> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<category> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<category> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<category> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<category> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "CategoryID";
        }

        public object KeyValue()
        {
            return this.CategoryID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.CategoryName.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(category)){
                category compare=(category)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.CategoryID;
        }
        
        public string DescriptorValue()
        {
                            return this.CategoryName.ToString();
                    }

        public string DescriptorColumn() {
            return "CategoryName";
        }
        public static string GetKeyColumn()
        {
            return "CategoryID";
        }        
        public static string GetDescriptorColumn()
        {
            return "CategoryName";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _CategoryID;
        public int CategoryID
        {
            get { return _CategoryID; }
            set
            {
                if(_CategoryID!=value){
                    _CategoryID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CategoryID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _CategoryName;
        public string CategoryName
        {
            get { return _CategoryName; }
            set
            {
                if(_CategoryName!=value){
                    _CategoryName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CategoryName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Description;
        public string Description
        {
            get { return _Description; }
            set
            {
                if(_Description!=value){
                    _Description=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Description");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte[] _Picture;
        public byte[] Picture
        {
            get { return _Picture; }
            set
            {
                if(_Picture!=value){
                    _Picture=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Picture");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<category, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the customercustomerdemo table in the Northwind Database.
    /// </summary>
    public partial class customercustomerdemo: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<customercustomerdemo> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<customercustomerdemo>(new Northwind.Data.NorthwindDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<customercustomerdemo> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(customercustomerdemo item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                customercustomerdemo item=new customercustomerdemo();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<customercustomerdemo> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Northwind.Data.NorthwindDB _db;
        public customercustomerdemo(string connectionString, string providerName) {

            _db=new Northwind.Data.NorthwindDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                customercustomerdemo.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<customercustomerdemo>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public customercustomerdemo(){
             _db=new Northwind.Data.NorthwindDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public customercustomerdemo(Expression<Func<customercustomerdemo, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<customercustomerdemo> GetRepo(string connectionString, string providerName){
            Northwind.Data.NorthwindDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Northwind.Data.NorthwindDB();
            }else{
                db=new Northwind.Data.NorthwindDB(connectionString, providerName);
            }
            IRepository<customercustomerdemo> _repo;
            
            if(db.TestMode){
                customercustomerdemo.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<customercustomerdemo>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<customercustomerdemo> GetRepo(){
            return GetRepo("","");
        }
        
        public static customercustomerdemo SingleOrDefault(Expression<Func<customercustomerdemo, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            customercustomerdemo single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static customercustomerdemo SingleOrDefault(Expression<Func<customercustomerdemo, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            customercustomerdemo single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<customercustomerdemo, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<customercustomerdemo, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<customercustomerdemo> Find(Expression<Func<customercustomerdemo, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<customercustomerdemo> Find(Expression<Func<customercustomerdemo, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<customercustomerdemo> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<customercustomerdemo> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<customercustomerdemo> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<customercustomerdemo> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<customercustomerdemo> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<customercustomerdemo> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "CustomerID";
        }

        public object KeyValue()
        {
            return this.CustomerID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<string>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.CustomerID.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(customercustomerdemo)){
                customercustomerdemo compare=(customercustomerdemo)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
                            return this.CustomerID.ToString();
                    }

        public string DescriptorColumn() {
            return "CustomerID";
        }
        public static string GetKeyColumn()
        {
            return "CustomerID";
        }        
        public static string GetDescriptorColumn()
        {
            return "CustomerID";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        string _CustomerID;
        public string CustomerID
        {
            get { return _CustomerID; }
            set
            {
                if(_CustomerID!=value){
                    _CustomerID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CustomerID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _CustomerTypeID;
        public string CustomerTypeID
        {
            get { return _CustomerTypeID; }
            set
            {
                if(_CustomerTypeID!=value){
                    _CustomerTypeID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CustomerTypeID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<customercustomerdemo, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the customerdemographics table in the Northwind Database.
    /// </summary>
    public partial class customerdemographic: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<customerdemographic> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<customerdemographic>(new Northwind.Data.NorthwindDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<customerdemographic> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(customerdemographic item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                customerdemographic item=new customerdemographic();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<customerdemographic> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Northwind.Data.NorthwindDB _db;
        public customerdemographic(string connectionString, string providerName) {

            _db=new Northwind.Data.NorthwindDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                customerdemographic.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<customerdemographic>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public customerdemographic(){
             _db=new Northwind.Data.NorthwindDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public customerdemographic(Expression<Func<customerdemographic, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<customerdemographic> GetRepo(string connectionString, string providerName){
            Northwind.Data.NorthwindDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Northwind.Data.NorthwindDB();
            }else{
                db=new Northwind.Data.NorthwindDB(connectionString, providerName);
            }
            IRepository<customerdemographic> _repo;
            
            if(db.TestMode){
                customerdemographic.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<customerdemographic>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<customerdemographic> GetRepo(){
            return GetRepo("","");
        }
        
        public static customerdemographic SingleOrDefault(Expression<Func<customerdemographic, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            customerdemographic single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static customerdemographic SingleOrDefault(Expression<Func<customerdemographic, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            customerdemographic single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<customerdemographic, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<customerdemographic, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<customerdemographic> Find(Expression<Func<customerdemographic, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<customerdemographic> Find(Expression<Func<customerdemographic, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<customerdemographic> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<customerdemographic> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<customerdemographic> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<customerdemographic> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<customerdemographic> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<customerdemographic> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "CustomerTypeID";
        }

        public object KeyValue()
        {
            return this.CustomerTypeID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<string>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.CustomerTypeID.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(customerdemographic)){
                customerdemographic compare=(customerdemographic)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
                            return this.CustomerTypeID.ToString();
                    }

        public string DescriptorColumn() {
            return "CustomerTypeID";
        }
        public static string GetKeyColumn()
        {
            return "CustomerTypeID";
        }        
        public static string GetDescriptorColumn()
        {
            return "CustomerTypeID";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        string _CustomerTypeID;
        public string CustomerTypeID
        {
            get { return _CustomerTypeID; }
            set
            {
                if(_CustomerTypeID!=value){
                    _CustomerTypeID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CustomerTypeID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _CustomerDesc;
        public string CustomerDesc
        {
            get { return _CustomerDesc; }
            set
            {
                if(_CustomerDesc!=value){
                    _CustomerDesc=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CustomerDesc");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<customerdemographic, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the customers table in the Northwind Database.
    /// </summary>
    public partial class customer: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<customer> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<customer>(new Northwind.Data.NorthwindDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<customer> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(customer item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                customer item=new customer();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<customer> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Northwind.Data.NorthwindDB _db;
        public customer(string connectionString, string providerName) {

            _db=new Northwind.Data.NorthwindDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                customer.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<customer>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public customer(){
             _db=new Northwind.Data.NorthwindDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public customer(Expression<Func<customer, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<customer> GetRepo(string connectionString, string providerName){
            Northwind.Data.NorthwindDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Northwind.Data.NorthwindDB();
            }else{
                db=new Northwind.Data.NorthwindDB(connectionString, providerName);
            }
            IRepository<customer> _repo;
            
            if(db.TestMode){
                customer.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<customer>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<customer> GetRepo(){
            return GetRepo("","");
        }
        
        public static customer SingleOrDefault(Expression<Func<customer, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            customer single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static customer SingleOrDefault(Expression<Func<customer, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            customer single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<customer, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<customer, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<customer> Find(Expression<Func<customer, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<customer> Find(Expression<Func<customer, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<customer> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<customer> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<customer> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<customer> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<customer> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<customer> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "CustomerID";
        }

        public object KeyValue()
        {
            return this.CustomerID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<string>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.CustomerID.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(customer)){
                customer compare=(customer)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
                            return this.CustomerID.ToString();
                    }

        public string DescriptorColumn() {
            return "CustomerID";
        }
        public static string GetKeyColumn()
        {
            return "CustomerID";
        }        
        public static string GetDescriptorColumn()
        {
            return "CustomerID";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        string _CustomerID;
        public string CustomerID
        {
            get { return _CustomerID; }
            set
            {
                if(_CustomerID!=value){
                    _CustomerID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CustomerID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _CompanyName;
        public string CompanyName
        {
            get { return _CompanyName; }
            set
            {
                if(_CompanyName!=value){
                    _CompanyName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CompanyName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _ContactName;
        public string ContactName
        {
            get { return _ContactName; }
            set
            {
                if(_ContactName!=value){
                    _ContactName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ContactName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _ContactTitle;
        public string ContactTitle
        {
            get { return _ContactTitle; }
            set
            {
                if(_ContactTitle!=value){
                    _ContactTitle=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ContactTitle");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Address;
        public string Address
        {
            get { return _Address; }
            set
            {
                if(_Address!=value){
                    _Address=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Address");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _City;
        public string City
        {
            get { return _City; }
            set
            {
                if(_City!=value){
                    _City=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="City");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Region;
        public string Region
        {
            get { return _Region; }
            set
            {
                if(_Region!=value){
                    _Region=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Region");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _PostalCode;
        public string PostalCode
        {
            get { return _PostalCode; }
            set
            {
                if(_PostalCode!=value){
                    _PostalCode=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PostalCode");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Country;
        public string Country
        {
            get { return _Country; }
            set
            {
                if(_Country!=value){
                    _Country=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Country");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Phone;
        public string Phone
        {
            get { return _Phone; }
            set
            {
                if(_Phone!=value){
                    _Phone=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Phone");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Fax;
        public string Fax
        {
            get { return _Fax; }
            set
            {
                if(_Fax!=value){
                    _Fax=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Fax");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<customer, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the employees table in the Northwind Database.
    /// </summary>
    public partial class employee: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<employee> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<employee>(new Northwind.Data.NorthwindDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<employee> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(employee item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                employee item=new employee();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<employee> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Northwind.Data.NorthwindDB _db;
        public employee(string connectionString, string providerName) {

            _db=new Northwind.Data.NorthwindDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                employee.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<employee>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public employee(){
             _db=new Northwind.Data.NorthwindDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public employee(Expression<Func<employee, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<employee> GetRepo(string connectionString, string providerName){
            Northwind.Data.NorthwindDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Northwind.Data.NorthwindDB();
            }else{
                db=new Northwind.Data.NorthwindDB(connectionString, providerName);
            }
            IRepository<employee> _repo;
            
            if(db.TestMode){
                employee.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<employee>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<employee> GetRepo(){
            return GetRepo("","");
        }
        
        public static employee SingleOrDefault(Expression<Func<employee, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            employee single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static employee SingleOrDefault(Expression<Func<employee, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            employee single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<employee, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<employee, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<employee> Find(Expression<Func<employee, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<employee> Find(Expression<Func<employee, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<employee> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<employee> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<employee> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<employee> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<employee> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<employee> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "EmployeeID";
        }

        public object KeyValue()
        {
            return this.EmployeeID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.LastName.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(employee)){
                employee compare=(employee)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.EmployeeID;
        }
        
        public string DescriptorValue()
        {
                            return this.LastName.ToString();
                    }

        public string DescriptorColumn() {
            return "LastName";
        }
        public static string GetKeyColumn()
        {
            return "EmployeeID";
        }        
        public static string GetDescriptorColumn()
        {
            return "LastName";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _EmployeeID;
        public int EmployeeID
        {
            get { return _EmployeeID; }
            set
            {
                if(_EmployeeID!=value){
                    _EmployeeID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="EmployeeID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _LastName;
        public string LastName
        {
            get { return _LastName; }
            set
            {
                if(_LastName!=value){
                    _LastName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="LastName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if(_FirstName!=value){
                    _FirstName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="FirstName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Title;
        public string Title
        {
            get { return _Title; }
            set
            {
                if(_Title!=value){
                    _Title=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Title");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _TitleOfCourtesy;
        public string TitleOfCourtesy
        {
            get { return _TitleOfCourtesy; }
            set
            {
                if(_TitleOfCourtesy!=value){
                    _TitleOfCourtesy=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TitleOfCourtesy");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _BirthDate;
        public DateTime? BirthDate
        {
            get { return _BirthDate; }
            set
            {
                if(_BirthDate!=value){
                    _BirthDate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="BirthDate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _HireDate;
        public DateTime? HireDate
        {
            get { return _HireDate; }
            set
            {
                if(_HireDate!=value){
                    _HireDate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="HireDate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Address;
        public string Address
        {
            get { return _Address; }
            set
            {
                if(_Address!=value){
                    _Address=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Address");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _City;
        public string City
        {
            get { return _City; }
            set
            {
                if(_City!=value){
                    _City=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="City");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Region;
        public string Region
        {
            get { return _Region; }
            set
            {
                if(_Region!=value){
                    _Region=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Region");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _PostalCode;
        public string PostalCode
        {
            get { return _PostalCode; }
            set
            {
                if(_PostalCode!=value){
                    _PostalCode=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PostalCode");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Country;
        public string Country
        {
            get { return _Country; }
            set
            {
                if(_Country!=value){
                    _Country=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Country");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _HomePhone;
        public string HomePhone
        {
            get { return _HomePhone; }
            set
            {
                if(_HomePhone!=value){
                    _HomePhone=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="HomePhone");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Extension;
        public string Extension
        {
            get { return _Extension; }
            set
            {
                if(_Extension!=value){
                    _Extension=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Extension");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        byte[] _Photo;
        public byte[] Photo
        {
            get { return _Photo; }
            set
            {
                if(_Photo!=value){
                    _Photo=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Photo");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Notes;
        public string Notes
        {
            get { return _Notes; }
            set
            {
                if(_Notes!=value){
                    _Notes=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Notes");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _ReportsTo;
        public int? ReportsTo
        {
            get { return _ReportsTo; }
            set
            {
                if(_ReportsTo!=value){
                    _ReportsTo=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ReportsTo");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _PhotoPath;
        public string PhotoPath
        {
            get { return _PhotoPath; }
            set
            {
                if(_PhotoPath!=value){
                    _PhotoPath=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PhotoPath");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<employee, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the employeeterritories table in the Northwind Database.
    /// </summary>
    public partial class employeeterritory: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<employeeterritory> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<employeeterritory>(new Northwind.Data.NorthwindDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<employeeterritory> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(employeeterritory item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                employeeterritory item=new employeeterritory();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<employeeterritory> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Northwind.Data.NorthwindDB _db;
        public employeeterritory(string connectionString, string providerName) {

            _db=new Northwind.Data.NorthwindDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                employeeterritory.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<employeeterritory>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public employeeterritory(){
             _db=new Northwind.Data.NorthwindDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public employeeterritory(Expression<Func<employeeterritory, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<employeeterritory> GetRepo(string connectionString, string providerName){
            Northwind.Data.NorthwindDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Northwind.Data.NorthwindDB();
            }else{
                db=new Northwind.Data.NorthwindDB(connectionString, providerName);
            }
            IRepository<employeeterritory> _repo;
            
            if(db.TestMode){
                employeeterritory.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<employeeterritory>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<employeeterritory> GetRepo(){
            return GetRepo("","");
        }
        
        public static employeeterritory SingleOrDefault(Expression<Func<employeeterritory, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            employeeterritory single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static employeeterritory SingleOrDefault(Expression<Func<employeeterritory, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            employeeterritory single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<employeeterritory, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<employeeterritory, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<employeeterritory> Find(Expression<Func<employeeterritory, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<employeeterritory> Find(Expression<Func<employeeterritory, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<employeeterritory> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<employeeterritory> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<employeeterritory> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<employeeterritory> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<employeeterritory> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<employeeterritory> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "EmployeeID";
        }

        public object KeyValue()
        {
            return this.EmployeeID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.TerritoryID.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(employeeterritory)){
                employeeterritory compare=(employeeterritory)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.EmployeeID;
        }
        
        public string DescriptorValue()
        {
                            return this.TerritoryID.ToString();
                    }

        public string DescriptorColumn() {
            return "TerritoryID";
        }
        public static string GetKeyColumn()
        {
            return "EmployeeID";
        }        
        public static string GetDescriptorColumn()
        {
            return "TerritoryID";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _EmployeeID;
        public int EmployeeID
        {
            get { return _EmployeeID; }
            set
            {
                if(_EmployeeID!=value){
                    _EmployeeID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="EmployeeID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _TerritoryID;
        public string TerritoryID
        {
            get { return _TerritoryID; }
            set
            {
                if(_TerritoryID!=value){
                    _TerritoryID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TerritoryID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<employeeterritory, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the order_details table in the Northwind Database.
    /// </summary>
    public partial class order_detail: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<order_detail> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<order_detail>(new Northwind.Data.NorthwindDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<order_detail> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(order_detail item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                order_detail item=new order_detail();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<order_detail> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Northwind.Data.NorthwindDB _db;
        public order_detail(string connectionString, string providerName) {

            _db=new Northwind.Data.NorthwindDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                order_detail.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<order_detail>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public order_detail(){
             _db=new Northwind.Data.NorthwindDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public order_detail(Expression<Func<order_detail, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<order_detail> GetRepo(string connectionString, string providerName){
            Northwind.Data.NorthwindDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Northwind.Data.NorthwindDB();
            }else{
                db=new Northwind.Data.NorthwindDB(connectionString, providerName);
            }
            IRepository<order_detail> _repo;
            
            if(db.TestMode){
                order_detail.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<order_detail>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<order_detail> GetRepo(){
            return GetRepo("","");
        }
        
        public static order_detail SingleOrDefault(Expression<Func<order_detail, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            order_detail single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static order_detail SingleOrDefault(Expression<Func<order_detail, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            order_detail single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<order_detail, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<order_detail, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<order_detail> Find(Expression<Func<order_detail, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<order_detail> Find(Expression<Func<order_detail, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<order_detail> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<order_detail> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<order_detail> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<order_detail> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<order_detail> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<order_detail> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "OrderID";
        }

        public object KeyValue()
        {
            return this.OrderID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.ProductID.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(order_detail)){
                order_detail compare=(order_detail)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.OrderID;
        }
        
        public string DescriptorValue()
        {
                            return this.ProductID.ToString();
                    }

        public string DescriptorColumn() {
            return "ProductID";
        }
        public static string GetKeyColumn()
        {
            return "OrderID";
        }        
        public static string GetDescriptorColumn()
        {
            return "ProductID";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _OrderID;
        public int OrderID
        {
            get { return _OrderID; }
            set
            {
                if(_OrderID!=value){
                    _OrderID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="OrderID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _ProductID;
        public int ProductID
        {
            get { return _ProductID; }
            set
            {
                if(_ProductID!=value){
                    _ProductID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ProductID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal _UnitPrice;
        public decimal UnitPrice
        {
            get { return _UnitPrice; }
            set
            {
                if(_UnitPrice!=value){
                    _UnitPrice=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="UnitPrice");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short _Quantity;
        public short Quantity
        {
            get { return _Quantity; }
            set
            {
                if(_Quantity!=value){
                    _Quantity=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Quantity");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        double _Discount;
        public double Discount
        {
            get { return _Discount; }
            set
            {
                if(_Discount!=value){
                    _Discount=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Discount");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<order_detail, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the orders table in the Northwind Database.
    /// </summary>
    public partial class order: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<order> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<order>(new Northwind.Data.NorthwindDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<order> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(order item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                order item=new order();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<order> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Northwind.Data.NorthwindDB _db;
        public order(string connectionString, string providerName) {

            _db=new Northwind.Data.NorthwindDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                order.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<order>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public order(){
             _db=new Northwind.Data.NorthwindDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public order(Expression<Func<order, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<order> GetRepo(string connectionString, string providerName){
            Northwind.Data.NorthwindDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Northwind.Data.NorthwindDB();
            }else{
                db=new Northwind.Data.NorthwindDB(connectionString, providerName);
            }
            IRepository<order> _repo;
            
            if(db.TestMode){
                order.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<order>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<order> GetRepo(){
            return GetRepo("","");
        }
        
        public static order SingleOrDefault(Expression<Func<order, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            order single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static order SingleOrDefault(Expression<Func<order, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            order single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<order, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<order, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<order> Find(Expression<Func<order, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<order> Find(Expression<Func<order, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<order> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<order> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<order> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<order> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<order> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<order> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "OrderID";
        }

        public object KeyValue()
        {
            return this.OrderID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.CustomerID.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(order)){
                order compare=(order)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.OrderID;
        }
        
        public string DescriptorValue()
        {
                            return this.CustomerID.ToString();
                    }

        public string DescriptorColumn() {
            return "CustomerID";
        }
        public static string GetKeyColumn()
        {
            return "OrderID";
        }        
        public static string GetDescriptorColumn()
        {
            return "CustomerID";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _OrderID;
        public int OrderID
        {
            get { return _OrderID; }
            set
            {
                if(_OrderID!=value){
                    _OrderID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="OrderID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _CustomerID;
        public string CustomerID
        {
            get { return _CustomerID; }
            set
            {
                if(_CustomerID!=value){
                    _CustomerID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CustomerID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _EmployeeID;
        public int? EmployeeID
        {
            get { return _EmployeeID; }
            set
            {
                if(_EmployeeID!=value){
                    _EmployeeID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="EmployeeID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _OrderDate;
        public DateTime? OrderDate
        {
            get { return _OrderDate; }
            set
            {
                if(_OrderDate!=value){
                    _OrderDate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="OrderDate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _RequiredDate;
        public DateTime? RequiredDate
        {
            get { return _RequiredDate; }
            set
            {
                if(_RequiredDate!=value){
                    _RequiredDate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="RequiredDate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        DateTime? _ShippedDate;
        public DateTime? ShippedDate
        {
            get { return _ShippedDate; }
            set
            {
                if(_ShippedDate!=value){
                    _ShippedDate=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ShippedDate");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _ShipVia;
        public int? ShipVia
        {
            get { return _ShipVia; }
            set
            {
                if(_ShipVia!=value){
                    _ShipVia=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ShipVia");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _Freight;
        public decimal? Freight
        {
            get { return _Freight; }
            set
            {
                if(_Freight!=value){
                    _Freight=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Freight");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _ShipName;
        public string ShipName
        {
            get { return _ShipName; }
            set
            {
                if(_ShipName!=value){
                    _ShipName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ShipName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _ShipAddress;
        public string ShipAddress
        {
            get { return _ShipAddress; }
            set
            {
                if(_ShipAddress!=value){
                    _ShipAddress=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ShipAddress");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _ShipCity;
        public string ShipCity
        {
            get { return _ShipCity; }
            set
            {
                if(_ShipCity!=value){
                    _ShipCity=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ShipCity");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _ShipRegion;
        public string ShipRegion
        {
            get { return _ShipRegion; }
            set
            {
                if(_ShipRegion!=value){
                    _ShipRegion=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ShipRegion");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _ShipPostalCode;
        public string ShipPostalCode
        {
            get { return _ShipPostalCode; }
            set
            {
                if(_ShipPostalCode!=value){
                    _ShipPostalCode=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ShipPostalCode");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _ShipCountry;
        public string ShipCountry
        {
            get { return _ShipCountry; }
            set
            {
                if(_ShipCountry!=value){
                    _ShipCountry=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ShipCountry");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<order, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the products table in the Northwind Database.
    /// </summary>
    public partial class product: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<product> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<product>(new Northwind.Data.NorthwindDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<product> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(product item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                product item=new product();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<product> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Northwind.Data.NorthwindDB _db;
        public product(string connectionString, string providerName) {

            _db=new Northwind.Data.NorthwindDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                product.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<product>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public product(){
             _db=new Northwind.Data.NorthwindDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public product(Expression<Func<product, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<product> GetRepo(string connectionString, string providerName){
            Northwind.Data.NorthwindDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Northwind.Data.NorthwindDB();
            }else{
                db=new Northwind.Data.NorthwindDB(connectionString, providerName);
            }
            IRepository<product> _repo;
            
            if(db.TestMode){
                product.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<product>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<product> GetRepo(){
            return GetRepo("","");
        }
        
        public static product SingleOrDefault(Expression<Func<product, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            product single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static product SingleOrDefault(Expression<Func<product, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            product single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<product, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<product, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<product> Find(Expression<Func<product, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<product> Find(Expression<Func<product, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<product> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<product> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<product> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<product> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<product> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<product> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "ProductID";
        }

        public object KeyValue()
        {
            return this.ProductID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.ProductName.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(product)){
                product compare=(product)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.ProductID;
        }
        
        public string DescriptorValue()
        {
                            return this.ProductName.ToString();
                    }

        public string DescriptorColumn() {
            return "ProductName";
        }
        public static string GetKeyColumn()
        {
            return "ProductID";
        }        
        public static string GetDescriptorColumn()
        {
            return "ProductName";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _ProductID;
        public int ProductID
        {
            get { return _ProductID; }
            set
            {
                if(_ProductID!=value){
                    _ProductID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ProductID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _ProductName;
        public string ProductName
        {
            get { return _ProductName; }
            set
            {
                if(_ProductName!=value){
                    _ProductName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ProductName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _SupplierID;
        public int? SupplierID
        {
            get { return _SupplierID; }
            set
            {
                if(_SupplierID!=value){
                    _SupplierID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SupplierID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int? _CategoryID;
        public int? CategoryID
        {
            get { return _CategoryID; }
            set
            {
                if(_CategoryID!=value){
                    _CategoryID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CategoryID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _QuantityPerUnit;
        public string QuantityPerUnit
        {
            get { return _QuantityPerUnit; }
            set
            {
                if(_QuantityPerUnit!=value){
                    _QuantityPerUnit=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="QuantityPerUnit");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        decimal? _UnitPrice;
        public decimal? UnitPrice
        {
            get { return _UnitPrice; }
            set
            {
                if(_UnitPrice!=value){
                    _UnitPrice=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="UnitPrice");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _UnitsInStock;
        public short? UnitsInStock
        {
            get { return _UnitsInStock; }
            set
            {
                if(_UnitsInStock!=value){
                    _UnitsInStock=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="UnitsInStock");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _UnitsOnOrder;
        public short? UnitsOnOrder
        {
            get { return _UnitsOnOrder; }
            set
            {
                if(_UnitsOnOrder!=value){
                    _UnitsOnOrder=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="UnitsOnOrder");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        short? _ReorderLevel;
        public short? ReorderLevel
        {
            get { return _ReorderLevel; }
            set
            {
                if(_ReorderLevel!=value){
                    _ReorderLevel=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ReorderLevel");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        sbyte _Discontinued;
        public sbyte Discontinued
        {
            get { return _Discontinued; }
            set
            {
                if(_Discontinued!=value){
                    _Discontinued=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Discontinued");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<product, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the region table in the Northwind Database.
    /// </summary>
    public partial class region: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<region> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<region>(new Northwind.Data.NorthwindDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<region> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(region item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                region item=new region();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<region> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Northwind.Data.NorthwindDB _db;
        public region(string connectionString, string providerName) {

            _db=new Northwind.Data.NorthwindDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                region.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<region>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public region(){
             _db=new Northwind.Data.NorthwindDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public region(Expression<Func<region, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<region> GetRepo(string connectionString, string providerName){
            Northwind.Data.NorthwindDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Northwind.Data.NorthwindDB();
            }else{
                db=new Northwind.Data.NorthwindDB(connectionString, providerName);
            }
            IRepository<region> _repo;
            
            if(db.TestMode){
                region.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<region>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<region> GetRepo(){
            return GetRepo("","");
        }
        
        public static region SingleOrDefault(Expression<Func<region, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            region single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static region SingleOrDefault(Expression<Func<region, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            region single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<region, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<region, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<region> Find(Expression<Func<region, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<region> Find(Expression<Func<region, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<region> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<region> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<region> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<region> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<region> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<region> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "RegionID";
        }

        public object KeyValue()
        {
            return this.RegionID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.RegionDescription.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(region)){
                region compare=(region)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.RegionID;
        }
        
        public string DescriptorValue()
        {
                            return this.RegionDescription.ToString();
                    }

        public string DescriptorColumn() {
            return "RegionDescription";
        }
        public static string GetKeyColumn()
        {
            return "RegionID";
        }        
        public static string GetDescriptorColumn()
        {
            return "RegionDescription";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _RegionID;
        public int RegionID
        {
            get { return _RegionID; }
            set
            {
                if(_RegionID!=value){
                    _RegionID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="RegionID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _RegionDescription;
        public string RegionDescription
        {
            get { return _RegionDescription; }
            set
            {
                if(_RegionDescription!=value){
                    _RegionDescription=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="RegionDescription");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<region, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the shippers table in the Northwind Database.
    /// </summary>
    public partial class shipper: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<shipper> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<shipper>(new Northwind.Data.NorthwindDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<shipper> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(shipper item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                shipper item=new shipper();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<shipper> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Northwind.Data.NorthwindDB _db;
        public shipper(string connectionString, string providerName) {

            _db=new Northwind.Data.NorthwindDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                shipper.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<shipper>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public shipper(){
             _db=new Northwind.Data.NorthwindDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public shipper(Expression<Func<shipper, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<shipper> GetRepo(string connectionString, string providerName){
            Northwind.Data.NorthwindDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Northwind.Data.NorthwindDB();
            }else{
                db=new Northwind.Data.NorthwindDB(connectionString, providerName);
            }
            IRepository<shipper> _repo;
            
            if(db.TestMode){
                shipper.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<shipper>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<shipper> GetRepo(){
            return GetRepo("","");
        }
        
        public static shipper SingleOrDefault(Expression<Func<shipper, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            shipper single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static shipper SingleOrDefault(Expression<Func<shipper, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            shipper single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<shipper, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<shipper, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<shipper> Find(Expression<Func<shipper, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<shipper> Find(Expression<Func<shipper, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<shipper> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<shipper> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<shipper> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<shipper> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<shipper> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<shipper> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "ShipperID";
        }

        public object KeyValue()
        {
            return this.ShipperID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.CompanyName.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(shipper)){
                shipper compare=(shipper)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.ShipperID;
        }
        
        public string DescriptorValue()
        {
                            return this.CompanyName.ToString();
                    }

        public string DescriptorColumn() {
            return "CompanyName";
        }
        public static string GetKeyColumn()
        {
            return "ShipperID";
        }        
        public static string GetDescriptorColumn()
        {
            return "CompanyName";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _ShipperID;
        public int ShipperID
        {
            get { return _ShipperID; }
            set
            {
                if(_ShipperID!=value){
                    _ShipperID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ShipperID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _CompanyName;
        public string CompanyName
        {
            get { return _CompanyName; }
            set
            {
                if(_CompanyName!=value){
                    _CompanyName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CompanyName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Phone;
        public string Phone
        {
            get { return _Phone; }
            set
            {
                if(_Phone!=value){
                    _Phone=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Phone");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<shipper, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the shippers_tmp table in the Northwind Database.
    /// </summary>
    public partial class shippers_tmp: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<shippers_tmp> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<shippers_tmp>(new Northwind.Data.NorthwindDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<shippers_tmp> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(shippers_tmp item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                shippers_tmp item=new shippers_tmp();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<shippers_tmp> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Northwind.Data.NorthwindDB _db;
        public shippers_tmp(string connectionString, string providerName) {

            _db=new Northwind.Data.NorthwindDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                shippers_tmp.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<shippers_tmp>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public shippers_tmp(){
             _db=new Northwind.Data.NorthwindDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public shippers_tmp(Expression<Func<shippers_tmp, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<shippers_tmp> GetRepo(string connectionString, string providerName){
            Northwind.Data.NorthwindDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Northwind.Data.NorthwindDB();
            }else{
                db=new Northwind.Data.NorthwindDB(connectionString, providerName);
            }
            IRepository<shippers_tmp> _repo;
            
            if(db.TestMode){
                shippers_tmp.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<shippers_tmp>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<shippers_tmp> GetRepo(){
            return GetRepo("","");
        }
        
        public static shippers_tmp SingleOrDefault(Expression<Func<shippers_tmp, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            shippers_tmp single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static shippers_tmp SingleOrDefault(Expression<Func<shippers_tmp, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            shippers_tmp single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<shippers_tmp, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<shippers_tmp, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<shippers_tmp> Find(Expression<Func<shippers_tmp, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<shippers_tmp> Find(Expression<Func<shippers_tmp, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<shippers_tmp> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<shippers_tmp> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<shippers_tmp> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<shippers_tmp> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<shippers_tmp> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<shippers_tmp> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "ShipperID";
        }

        public object KeyValue()
        {
            return this.ShipperID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.CompanyName.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(shippers_tmp)){
                shippers_tmp compare=(shippers_tmp)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.ShipperID;
        }
        
        public string DescriptorValue()
        {
                            return this.CompanyName.ToString();
                    }

        public string DescriptorColumn() {
            return "CompanyName";
        }
        public static string GetKeyColumn()
        {
            return "ShipperID";
        }        
        public static string GetDescriptorColumn()
        {
            return "CompanyName";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _ShipperID;
        public int ShipperID
        {
            get { return _ShipperID; }
            set
            {
                if(_ShipperID!=value){
                    _ShipperID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ShipperID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _CompanyName;
        public string CompanyName
        {
            get { return _CompanyName; }
            set
            {
                if(_CompanyName!=value){
                    _CompanyName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CompanyName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Phone;
        public string Phone
        {
            get { return _Phone; }
            set
            {
                if(_Phone!=value){
                    _Phone=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Phone");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<shippers_tmp, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the suppliers table in the Northwind Database.
    /// </summary>
    public partial class supplier: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<supplier> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<supplier>(new Northwind.Data.NorthwindDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<supplier> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(supplier item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                supplier item=new supplier();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<supplier> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Northwind.Data.NorthwindDB _db;
        public supplier(string connectionString, string providerName) {

            _db=new Northwind.Data.NorthwindDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                supplier.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<supplier>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public supplier(){
             _db=new Northwind.Data.NorthwindDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public supplier(Expression<Func<supplier, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<supplier> GetRepo(string connectionString, string providerName){
            Northwind.Data.NorthwindDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Northwind.Data.NorthwindDB();
            }else{
                db=new Northwind.Data.NorthwindDB(connectionString, providerName);
            }
            IRepository<supplier> _repo;
            
            if(db.TestMode){
                supplier.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<supplier>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<supplier> GetRepo(){
            return GetRepo("","");
        }
        
        public static supplier SingleOrDefault(Expression<Func<supplier, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            supplier single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static supplier SingleOrDefault(Expression<Func<supplier, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            supplier single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<supplier, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<supplier, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<supplier> Find(Expression<Func<supplier, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<supplier> Find(Expression<Func<supplier, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<supplier> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<supplier> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<supplier> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<supplier> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<supplier> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<supplier> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "SupplierID";
        }

        public object KeyValue()
        {
            return this.SupplierID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.CompanyName.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(supplier)){
                supplier compare=(supplier)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.SupplierID;
        }
        
        public string DescriptorValue()
        {
                            return this.CompanyName.ToString();
                    }

        public string DescriptorColumn() {
            return "CompanyName";
        }
        public static string GetKeyColumn()
        {
            return "SupplierID";
        }        
        public static string GetDescriptorColumn()
        {
            return "CompanyName";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _SupplierID;
        public int SupplierID
        {
            get { return _SupplierID; }
            set
            {
                if(_SupplierID!=value){
                    _SupplierID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="SupplierID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _CompanyName;
        public string CompanyName
        {
            get { return _CompanyName; }
            set
            {
                if(_CompanyName!=value){
                    _CompanyName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="CompanyName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _ContactName;
        public string ContactName
        {
            get { return _ContactName; }
            set
            {
                if(_ContactName!=value){
                    _ContactName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ContactName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _ContactTitle;
        public string ContactTitle
        {
            get { return _ContactTitle; }
            set
            {
                if(_ContactTitle!=value){
                    _ContactTitle=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="ContactTitle");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Address;
        public string Address
        {
            get { return _Address; }
            set
            {
                if(_Address!=value){
                    _Address=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Address");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _City;
        public string City
        {
            get { return _City; }
            set
            {
                if(_City!=value){
                    _City=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="City");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Region;
        public string Region
        {
            get { return _Region; }
            set
            {
                if(_Region!=value){
                    _Region=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Region");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _PostalCode;
        public string PostalCode
        {
            get { return _PostalCode; }
            set
            {
                if(_PostalCode!=value){
                    _PostalCode=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="PostalCode");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Country;
        public string Country
        {
            get { return _Country; }
            set
            {
                if(_Country!=value){
                    _Country=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Country");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Phone;
        public string Phone
        {
            get { return _Phone; }
            set
            {
                if(_Phone!=value){
                    _Phone=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Phone");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _Fax;
        public string Fax
        {
            get { return _Fax; }
            set
            {
                if(_Fax!=value){
                    _Fax=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="Fax");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _HomePage;
        public string HomePage
        {
            get { return _HomePage; }
            set
            {
                if(_HomePage!=value){
                    _HomePage=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="HomePage");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<supplier, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the territories table in the Northwind Database.
    /// </summary>
    public partial class territory: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<territory> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<territory>(new Northwind.Data.NorthwindDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<territory> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(territory item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                territory item=new territory();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<territory> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Northwind.Data.NorthwindDB _db;
        public territory(string connectionString, string providerName) {

            _db=new Northwind.Data.NorthwindDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                territory.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<territory>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public territory(){
             _db=new Northwind.Data.NorthwindDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public territory(Expression<Func<territory, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<territory> GetRepo(string connectionString, string providerName){
            Northwind.Data.NorthwindDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Northwind.Data.NorthwindDB();
            }else{
                db=new Northwind.Data.NorthwindDB(connectionString, providerName);
            }
            IRepository<territory> _repo;
            
            if(db.TestMode){
                territory.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<territory>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<territory> GetRepo(){
            return GetRepo("","");
        }
        
        public static territory SingleOrDefault(Expression<Func<territory, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            territory single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static territory SingleOrDefault(Expression<Func<territory, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            territory single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<territory, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<territory, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<territory> Find(Expression<Func<territory, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<territory> Find(Expression<Func<territory, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<territory> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<territory> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<territory> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<territory> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<territory> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<territory> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "TerritoryID";
        }

        public object KeyValue()
        {
            return this.TerritoryID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<string>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.TerritoryID.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(territory)){
                territory compare=(territory)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        public string DescriptorValue()
        {
                            return this.TerritoryID.ToString();
                    }

        public string DescriptorColumn() {
            return "TerritoryID";
        }
        public static string GetKeyColumn()
        {
            return "TerritoryID";
        }        
        public static string GetDescriptorColumn()
        {
            return "TerritoryID";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        string _TerritoryID;
        public string TerritoryID
        {
            get { return _TerritoryID; }
            set
            {
                if(_TerritoryID!=value){
                    _TerritoryID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TerritoryID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _TerritoryDescription;
        public string TerritoryDescription
        {
            get { return _TerritoryDescription; }
            set
            {
                if(_TerritoryDescription!=value){
                    _TerritoryDescription=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="TerritoryDescription");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        int _RegionID;
        public int RegionID
        {
            get { return _RegionID; }
            set
            {
                if(_RegionID!=value){
                    _RegionID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="RegionID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<territory, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
    
    
    /// <summary>
    /// A class which represents the usstates table in the Northwind Database.
    /// </summary>
    public partial class usstate: IActiveRecord
    {
    
        #region Built-in testing
        static TestRepository<usstate> _testRepo;
        

        
        static void SetTestRepo(){
            _testRepo = _testRepo ?? new TestRepository<usstate>(new Northwind.Data.NorthwindDB());
        }
        public static void ResetTestRepo(){
            _testRepo = null;
            SetTestRepo();
        }
        public static void Setup(List<usstate> testlist){
            SetTestRepo();
            foreach (var item in testlist)
            {
                _testRepo._items.Add(item);
            }
        }
        public static void Setup(usstate item) {
            SetTestRepo();
            _testRepo._items.Add(item);
        }
        public static void Setup(int testItems) {
            SetTestRepo();
            for(int i=0;i<testItems;i++){
                usstate item=new usstate();
                _testRepo._items.Add(item);
            }
        }
        
        public bool TestMode = false;


        #endregion

        IRepository<usstate> _repo;
        ITable tbl;
        bool _isNew;
        public bool IsNew(){
            return _isNew;
        }
        
        public void SetIsLoaded(bool isLoaded){
            _isLoaded=isLoaded;
            if(isLoaded)
                OnLoaded();
        }
        
        public void SetIsNew(bool isNew){
            _isNew=isNew;
        }
        bool _isLoaded;
        public bool IsLoaded(){
            return _isLoaded;
        }
                
        List<IColumn> _dirtyColumns;
        public bool IsDirty(){
            return _dirtyColumns.Count>0;
        }
        
        public List<IColumn> GetDirtyColumns (){
            return _dirtyColumns;
        }

        Northwind.Data.NorthwindDB _db;
        public usstate(string connectionString, string providerName) {

            _db=new Northwind.Data.NorthwindDB(connectionString, providerName);
            Init();            
         }
        void Init(){
            TestMode=this._db.DataProvider.ConnectionString.Equals("test", StringComparison.InvariantCultureIgnoreCase);
            _dirtyColumns=new List<IColumn>();
            if(TestMode){
                usstate.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<usstate>(_db);
            }
            tbl=_repo.GetTable();
            SetIsNew(true);
            OnCreated();       

        }
        
        public usstate(){
             _db=new Northwind.Data.NorthwindDB();
            Init();            
        }
        
       
        partial void OnCreated();
            
        partial void OnLoaded();
        
        partial void OnSaved();
        
        partial void OnChanged();
        
        public IList<IColumn> Columns{
            get{
                return tbl.Columns;
            }
        }

        public usstate(Expression<Func<usstate, bool>> expression):this() {

            SetIsLoaded(_repo.Load(this,expression));
        }
        
       
        
        internal static IRepository<usstate> GetRepo(string connectionString, string providerName){
            Northwind.Data.NorthwindDB db;
            if(String.IsNullOrEmpty(connectionString)){
                db=new Northwind.Data.NorthwindDB();
            }else{
                db=new Northwind.Data.NorthwindDB(connectionString, providerName);
            }
            IRepository<usstate> _repo;
            
            if(db.TestMode){
                usstate.SetTestRepo();
                _repo=_testRepo;
            }else{
                _repo = new SubSonicRepository<usstate>(db);
            }
            return _repo;        
        }       
        
        internal static IRepository<usstate> GetRepo(){
            return GetRepo("","");
        }
        
        public static usstate SingleOrDefault(Expression<Func<usstate, bool>> expression) {

            var repo = GetRepo();
            var results=repo.Find(expression);
            usstate single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
                single.OnLoaded();
                single.SetIsLoaded(true);
                single.SetIsNew(false);
            }

            return single;
        }      
        
        public static usstate SingleOrDefault(Expression<Func<usstate, bool>> expression,string connectionString, string providerName) {
            var repo = GetRepo(connectionString,providerName);
            var results=repo.Find(expression);
            usstate single=null;
            if(results.Count() > 0){
                single=results.ToList()[0];
            }

            return single;


        }
        
        
        public static bool Exists(Expression<Func<usstate, bool>> expression,string connectionString, string providerName) {
           
            return All(connectionString,providerName).Any(expression);
        }        
        public static bool Exists(Expression<Func<usstate, bool>> expression) {
           
            return All().Any(expression);
        }        

        public static IList<usstate> Find(Expression<Func<usstate, bool>> expression) {
            
            var repo = GetRepo();
            return repo.Find(expression).ToList();
        }
        
        public static IList<usstate> Find(Expression<Func<usstate, bool>> expression,string connectionString, string providerName) {

            var repo = GetRepo(connectionString,providerName);
            return repo.Find(expression).ToList();

        }
        public static IQueryable<usstate> All(string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetAll();
        }
        public static IQueryable<usstate> All() {
            return GetRepo().GetAll();
        }
        
        public static PagedList<usstate> GetPaged(string sortBy, int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(sortBy, pageIndex, pageSize);
        }
      
        public static PagedList<usstate> GetPaged(string sortBy, int pageIndex, int pageSize) {
            return GetRepo().GetPaged(sortBy, pageIndex, pageSize);
        }

        public static PagedList<usstate> GetPaged(int pageIndex, int pageSize,string connectionString, string providerName) {
            return GetRepo(connectionString,providerName).GetPaged(pageIndex, pageSize);
            
        }


        public static PagedList<usstate> GetPaged(int pageIndex, int pageSize) {
            return GetRepo().GetPaged(pageIndex, pageSize);
            
        }

        public string KeyName()
        {
            return "StateID";
        }

        public object KeyValue()
        {
            return this.StateID;
        }
        
        public void SetKeyValue(object value) {
            if (value != null && value!=DBNull.Value) {
                var settable = value.ChangeTypeTo<int>();
                this.GetType().GetProperty(this.KeyName()).SetValue(this, settable, null);
            }
        }
        
        public override string ToString(){
                            return this.StateName.ToString();
                    }

        public override bool Equals(object obj){
            if(obj.GetType()==typeof(usstate)){
                usstate compare=(usstate)obj;
                return compare.KeyValue()==this.KeyValue();
            }else{
                return base.Equals(obj);
            }
        }

        
        public override int GetHashCode() {
            return this.StateID;
        }
        
        public string DescriptorValue()
        {
                            return this.StateName.ToString();
                    }

        public string DescriptorColumn() {
            return "StateName";
        }
        public static string GetKeyColumn()
        {
            return "StateID";
        }        
        public static string GetDescriptorColumn()
        {
            return "StateName";
        }
        
        #region ' Foreign Keys '
        #endregion
        

        int _StateID;
        public int StateID
        {
            get { return _StateID; }
            set
            {
                if(_StateID!=value){
                    _StateID=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="StateID");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _StateName;
        public string StateName
        {
            get { return _StateName; }
            set
            {
                if(_StateName!=value){
                    _StateName=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="StateName");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _StateAbbr;
        public string StateAbbr
        {
            get { return _StateAbbr; }
            set
            {
                if(_StateAbbr!=value){
                    _StateAbbr=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="StateAbbr");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }

        string _StateRegion;
        public string StateRegion
        {
            get { return _StateRegion; }
            set
            {
                if(_StateRegion!=value){
                    _StateRegion=value;
                    var col=tbl.Columns.SingleOrDefault(x=>x.Name=="StateRegion");
                    if(col!=null){
                        if(!_dirtyColumns.Any(x=>x.Name==col.Name) && _isLoaded){
                            _dirtyColumns.Add(col);
                        }
                    }
                    OnChanged();
                }
            }
        }



        public DbCommand GetUpdateCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToUpdateQuery(_db.Provider).GetCommand().ToDbCommand();
            
        }
        public DbCommand GetInsertCommand() {
 
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToInsertQuery(_db.Provider).GetCommand().ToDbCommand();
        }
        
        public DbCommand GetDeleteCommand() {
            if(TestMode)
                return _db.DataProvider.CreateCommand();
            else
                return this.ToDeleteQuery(_db.Provider).GetCommand().ToDbCommand();
        }
       
        
        public void Update(){
            Update(_db.DataProvider);
        }
        
        public void Update(IDataProvider provider){
        
            
            if(this._dirtyColumns.Count>0){
                _repo.Update(this,provider);
                _dirtyColumns.Clear();    
            }
            OnSaved();
       }
 
        public void Add(){
            Add(_db.DataProvider);
        }
        
        
       
        public void Add(IDataProvider provider){

            
            var key=KeyValue();
            if(key==null){
                var newKey=_repo.Add(this,provider);
                this.SetKeyValue(newKey);
            }else{
                _repo.Add(this,provider);
            }
            SetIsNew(false);
            OnSaved();
        }
        
                
        
        public void Save() {
            Save(_db.DataProvider);
        }      
        public void Save(IDataProvider provider) {
            
           
            if (_isNew) {
                Add(provider);
                
            } else {
                Update(provider);
            }
            
        }

        

        public void Delete(IDataProvider provider) {
                   
                 
            _repo.Delete(KeyValue());
            
                    }


        public void Delete() {
            Delete(_db.DataProvider);
        }


        public static void Delete(Expression<Func<usstate, bool>> expression) {
            var repo = GetRepo();
            
       
            
            repo.DeleteMany(expression);
            
        }

        

        public void Load(IDataReader rdr) {
            Load(rdr, true);
        }
        public void Load(IDataReader rdr, bool closeReader) {
            if (rdr.Read()) {

                try {
                    rdr.Load(this);
                    SetIsNew(false);
                    SetIsLoaded(true);
                } catch {
                    SetIsLoaded(false);
                    throw;
                }
            }else{
                SetIsLoaded(false);
            }

            if (closeReader)
                rdr.Dispose();
        }
        

    } 
}
