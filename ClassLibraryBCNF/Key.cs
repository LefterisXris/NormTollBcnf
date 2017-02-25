using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Normalization
{
    /// <summary>
    /// Η κλάση Key δημιουργεί κλειδιά που περιλαμβάνουν γνωρίσματα (μονά ή και συνδυασμούς).
    /// </summary>
    public class Key
    {
        // ο πίνακας keyAttrs περιέχει τα γνωρίσματα που περιλαμβάνει το κλειδί.
        private List<Attr> keyAttrs = new List<Attr>();

        /// <summary>
        /// Προσθέτει ένα γνώρισμα τύπου Attr στο κλειδί.
        /// </summary>
        public void AddToKey(Attr attr)
        {
            keyAttrs.Add(attr);
        }

        /// <summary>
        /// Προσθέτει μια λίστα από γνωρίσματα στο κλειδί.
        /// </summary>
        public void AddToKey(List<Attr> list)
        {
            // ελέγχεται αν τα κλειδιά υπάρχουν ήδη στον πίνακα, κι αν όχι, προστίθενται.
            foreach (Attr attr in list)
                if (!keyAttrs.Contains(attr))
                    AddToKey(attr);
        }

        /// <summary>
        /// Επιστρέφει τον πίνακα με τα γνωρίσματα που περιλαμβάνονται στο κλειδί Key.
        /// </summary>
        public List<Attr> GetAttrs()
        {
            return keyAttrs;
        }

        //  KeyExistsfsdfg

        //        ToString




    }
}