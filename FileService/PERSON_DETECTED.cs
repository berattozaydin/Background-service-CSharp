using PetaPoco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FileService
{
    public class Record<T> : INotifyPropertyChanged where T : new()
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (!string.IsNullOrEmpty(propertyName))
            {
                MarkColumnModified(propertyName);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        [Ignore]
        [JsonIgnore]
        public List<string> ModifiedColumns { get; set; } = new List<string>();

        //[Ignore]
        //[JsonIgnore]
        //public Dictionary<string, bool> ModifiedColumns { get; set; } = new Dictionary<string, bool>();

        protected void MarkColumnModified([CallerMemberName] string column_name = null)
        {
            //if (ModifiedColumns != null)
            //    ModifiedColumns[column_name] = true;

            if (!ModifiedColumns.Exists(item => item == column_name))
            {
                ModifiedColumns.Add(column_name);
            }
        }

        private void OnLoaded()
        {

            if (ModifiedColumns == null)
            {
                ModifiedColumns = new List<string>();
            }
            else
            {
                ModifiedColumns.Clear();
            }
        }
    }

    [TableName("dbo.PERSON_DETECTED")]
    [PrimaryKey("ID")]
    [ExplicitColumns]
    public class PERSON_DETECTED : Record<PERSON_DETECTED>
    {
        [ResultColumn(IncludeInAutoSelect.Yes)]
        public int ID 
        { 
            get{ return _ID; } 
            set { _ID = value;OnPropertyChanged(); } 
        }
        int _ID;

        [Column]
        public int PERSON_COUNT 
        { 
            get { return _PERSON_COUNT; } 
            set { _PERSON_COUNT = value; OnPropertyChanged(); } 
        }
        int _PERSON_COUNT;
    }
}
