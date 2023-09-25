using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class BasicInfo
    {
        protected string _number;
        private string _legion;
        private string _unittype;
        private string _weapon;
        private string _squad;
        private string _group;
        private string _class;
        private Rank _rank;
        protected string[] missions;

        public string Legion    { get { return _legion; }       set { this._legion      = value; } }
        public string Number    { get { return _number; } }
        public string UnitType  { get { return _unittype; }     set { this._unittype    = value; } }
        public string Weapon    { get { return _weapon; }       set { _weapon           = value; } }
        public string Squad     { get { return _squad; }        set { this._squad       = value; } }
        public string Group     { get { return _group; }        set { this._group       = value; } }
        public string Class     { get { return _class; }        set { this._class       = value; } }
        public Rank Rank        { get { return _rank; }         set { this._rank        = value; } } 

        public BasicInfo() { }
        public BasicInfo(string _number, string _legion, string _unittype, string _weapon, string _squad, string _group, string _class, Rank _rank)
        {
            this._number = _number;
            this._legion = _legion;
            this._unittype = _unittype;
            this._weapon = _weapon;
            this._squad = _squad;
            this._group = _group;
            this._class = _class;
            this._rank = _rank;
        }

        public abstract Rank ReadRankFiles(string rankNumber);
        public abstract string[] getMissionNumber(string value);
    }
}
