using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Normalization
{
    public class FRMMAIN
    {
        string localApp = ""; //η διαδρομή όπου βρίσκεται ο φάκελος του προγράμματος με αρχεία όπως οι ρυθμίσεις
        private string scFilename = ""; //η ονομασία του αρχείου όπου αποθηκεύεται το σχήμα
        private string path = ""; //η πλήρης διαδρομή του αρχείου
        private string scDescription = ""; //η περιγραφή του σχήματος
        private List<Attr> attrList = new List<Attr>(); //δημιουργείται ο πίνακας attrList όπου αποθηκεύονται τα γνωρίσματα - αντικείμενα τύπου Attr
        private List<FD> FDList = new List<FD>(); //δημιουργείται ο πίνακας FDList όπου αποθηκεύονται οι συναρτησιακές εξαρτήσεις - αντικείμενα τύπου FD
        private List<byte> bin = new List<byte>(); //βοηθητικός πίνακας για το δυαδικό σύστημα, μετρά το πλήθος του ψηφίου 1
        private static bool isRunning;
        public static int MaxAttrNum = 20; //το μέγιστο πλήθος των επιτρεπόμενων γνωρισμάτων

        /// <summary>
        /// Κατασκευαστής της FRMAIN
        /// </summary>
        public FRMMAIN()
        {
            string str;
            int kk = (int)Math.Pow(2, MaxAttrNum);
            for (int i=0; i<=kk; i++)
            {
                // ο αριθμός i μετατρέπεται σε δύαδικό.
                str = Convert.ToString(i, 2);

                // μετριέται το πλήθος των ψηφίων 1 στον δυαδικό αριθμό str και καταχωρείται στον πίνακα bin.
                bin.Add((byte)str.Replace("0", "").Length);
            }
        }

        // SaveOptions()
        // LoadOptions()
        // mnuExit_Click()
        // FRMMAIN_FormClosing()

        private void mnuNew_Click(object sender, EventArgs e)
        {

        }
    }
}
