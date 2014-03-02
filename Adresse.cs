using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdressVerwaltung_V1
{
    [Serializable]
    class Adresse
    {
        private static List<Adresse> lAdresse = new List<Adresse>();
        internal static List<Adresse> LAdresse
        {
            get { return Adresse.lAdresse; }
            set { Adresse.lAdresse = value; }
        }

        private string m_strNachname;
        public string StrNachname
        {
            get { return m_strNachname; }
            set { m_strNachname = value; }
        }

        private string m_strVorname;
        public string StrVorname
        {
            get { return m_strVorname; }
            set { m_strVorname = value; }
        }

        private string m_strStrasse;
        public string StrStrasse
        {
            get { return m_strStrasse; }
            set { m_strStrasse = value; }
        }

        private string m_strHausnummer;
        public string StrHausnummer
        {
            get { return m_strHausnummer; }
            set { m_strHausnummer = value; }
        }

        private string m_strPostleitzahl;
        public string StrPostleitzahl
        {
            get { return m_strPostleitzahl; }
            set { m_strPostleitzahl = value; }
        }

        private string m_strOrt;
        public string StrOrt
        {
            get { return m_strOrt; }
            set { m_strOrt = value; }
        }

        private string m_eMail;
        public string EMail
        {
            get { return m_eMail; }
            set { m_eMail = value; }
        }

        private string m_ICQ;
        public string ICQ
        {
            get { return m_ICQ; }
            set { m_ICQ = value; }
        }

        public Adresse(string _nname, string _vname, string _strasse, string _hasunummer, string _plz, string _ort, string _email, string _icq)
        {
            StrNachname = _nname;
            StrVorname = _vname;
            StrStrasse = _strasse;
            StrHausnummer = _hasunummer;
            StrPostleitzahl = _plz;
            StrOrt = _ort;
            EMail = _email;
            ICQ = _icq;
            Adresse.LAdresse.Add(this);
        }

        public override string ToString()
        {
            return StrNachname+","+StrVorname;
        }
    }
}
