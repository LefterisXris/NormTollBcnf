using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Ctrl + M + O collaps all.  
// Ctrl + M + L expands all.
//auto format Ctrl + K , Ctrl + D   Για αυτόματη αντιστοίχηση.

namespace Normalization
{
    /// <summary>
    /// Η κλάση Attr δημιουργεί γνωρίσματα του σχήματος
    /// </summary>
    public class Attr
    {
        // μεταβλητές με τα χαρακτηριστικά του γνωρίσματος
        string name; // όνομα
        string type; // τύπος
        bool exclude; // αποκλείει τη συμμετοχή σε κλειδί

        /// <summary>
        /// Κατασκευαστής του γνωρίσματος Attr
        /// </summary>
        /// <param name="name">Ονομασία γνωρίσματος</param>
        /// <param name="type">Τύπος γνωρίσματος</param>
        public Attr(string name, string type)
        {
            // κατά τη δημιουργία του γνωρίσματος περνιούνται στις αντίστοιχες μεταβλητές η ονομασία και ο τύπος του.
            this.name = name;
            this.type = type;
        }

        /// <summary>
        /// Ονομασία του γνωρίσματος
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Τύπος του γνωρίσματος
        /// </summary>
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// Αποκλείει τη συμμετοχή σε κλειδί
        /// </summary>
        public bool Exclude
        {
            get { return exclude; }
            set { exclude = value; }
        }
    }
}