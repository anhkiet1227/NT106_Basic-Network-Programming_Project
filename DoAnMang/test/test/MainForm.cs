using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraRichEdit.API.Native;
using static DevExpress.XtraPrinting.Native.ExportOptionsPropertiesNames;
using DevExpress.XtraRichEdit;
using System.Threading;
using System.Timers;

namespace test
{
    public partial class MainForm : RibbonForm
    {
        private SetupRoom room1;
        public string pubRtf;
        public string pubPlaintext;
        public string pubLastGet;
        
        void connectRoom(SetupRoom room, bool disconnect)
        {
            if (room.connectGetSet == false)
            {
                bool connect = room.myConnectRoomGetSet.makeConnect(this, room.addressGetSet, room.portGetSet, "test");
                if (connect == true)
                {
                    room.connectGetSet = true;
                }
            }
            else if (disconnect == true)
            {
                room.myConnectRoomGetSet.makeDisconnect();
                room.connectGetSet = false;
            }
        }
        
        public MainForm()
        {
            InitializeComponent();
            InitializeRichEditControl();
            ribbonControl.SelectedPage = homeRibbonPage1;
            room1 = new SetupRoom("Room 1", "192.168.1.1", 1111);
            connectRoom(room1, true);            
        }
        
        void InitializeRichEditControl()
        {

        }

        private void iAbout_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void fileNewItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void toggleFontBoldItem1_CheckedChanged(object sender, ItemClickEventArgs e)
        {
        }

        private void fileOpenItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public string RtfToTxt(string rtfString)
        {

            RichEditDocumentServer dataGetFromServer = new RichEditDocumentServer();
            dataGetFromServer.RtfText = rtfString;
            string txt = dataGetFromServer.Text;
            return txt;
            

        }
        public string TxtToRtf(string txt)
        {
            RichEditDocumentServer dataGetFromServer = new RichEditDocumentServer();
            dataGetFromServer.Text = txt;
            string rtfString = dataGetFromServer.RtfText;
            return rtfString;
        }
                
        private void SendData_ItemClick(object sender, ItemClickEventArgs e)
        {
            Document document = richEditControl.Document;
            pubRtf = document.GetRtfText(document.Range);
            if (room1.connectGetSet == false)
            {
                return;
            }
            room1.myConnectRoomGetSet.SendData(pubRtf);
        }

        private void Perform_ItemClick(object sender, ItemClickEventArgs e)
        {
            string rtfIndex = Variable.pubRtf1;
            richEditControl.RtfText = rtfIndex;
        }


        string AutoCorrect(string content)
        {
            if (content == "" || content == null) return "";
            content = content.Replace("..", "...");
            content = content.Replace("\" ", "\"");
            content = content.Replace("\' ", "\'");
            content = content.Replace("( ", "(");
            content = content.Replace(" )", ")");
            char firstchar = content[0];
            content = content.Remove(0, 1);
            content = content.Insert(0, Char.ToUpper(firstchar).ToString());

            int countdocs = 0, countcomma = 0, countUp = 0, openbefore = 0, countspace = 0;
            string output = "";
            foreach (char chars in content)
            {
                if (chars == '.')
                {
                    if (countdocs < 3)
                    {
                        countdocs++;
                        output += chars;
                    }
                }
                else if ((chars == ';' || chars == ','))
                {
                    if (countcomma == 0)
                    {
                        countcomma++;
                        output += chars;
                    }
                }
                else if ((chars == '?' || chars == '!' || chars == ':' || chars == '-'))
                {
                    if (countUp == 0)
                    {
                        countUp++;
                        output += chars;
                    }
                }
                else if ((chars == '\"' || chars == '(' || chars == '\'') && openbefore == 0)
                {
                    {
                        ++openbefore;
                        if (countUp == 1)
                        {
                            if (output[output.Length - 1] != ' ') output += ' ';
                            output += chars;
                            countUp = 0;
                        }
                        else output += chars;
                    }
                }
                else if (chars == ' ')
                {
                    if (output[output.Length - 1] != ' ' && countspace == 0)
                    {
                        output += chars;
                        ++countspace;
                    }
                }
                else
                {
                    if (countdocs > 0)
                    {
                        if ((chars == '\"' || chars == ')' || chars == '\''))
                        {
                            openbefore = 0;
                            if (output[output.Length - 1] == ' ') output = output.Remove(output.Length - 1, 1);
                            output += chars.ToString() + ' ';
                        }
                        else
                        {
                            if (output[output.Length - 1] == ' ') output += (Char.ToUpper(chars)).ToString();
                            else output += ' ' + (Char.ToUpper(chars)).ToString();
                        }
                        countdocs = 0;
                    }
                    else if (countUp == 1)
                    {
                        if ((chars == '\"' || chars == ')' || chars == '\''))
                        {
                            openbefore = 0;
                            if (output[output.Length - 1] == ' ') output = output.Remove(output.Length - 1, 1);
                            output += chars.ToString() + ' ';
                        }
                        else
                        {
                            if (output[output.Length - 1] == ' ') output += (Char.ToUpper(chars)).ToString();
                            else output += ' ' + (Char.ToUpper(chars)).ToString();
                        }
                        countUp = 0;
                    }
                    else if (openbefore > 0 && (chars == '\"' || chars == ')' || chars == '\''))
                    {
                        openbefore = 0;
                        if (output[output.Length - 1] == ' ') output = output.Remove(output.Length - 1, 1);
                        output += chars.ToString() + ' ';
                    }
                    else if (countcomma == 1)
                    {
                        if (output[output.Length - 1] == ' ') output += (Char.ToLower(chars)).ToString();
                        else output += ' ' + Char.ToLower(chars).ToString();
                    }
                    else if (output.Length > 0 && output[output.Length - 1] == '\"') output += (Char.ToUpper(chars)).ToString();
                    else output += chars.ToString();
                    countspace = 0;
                    countdocs = 0;
                    countUp = 0;
                    countcomma = 0;
                }
            }
            output = output.Replace(" ,", ",");
            output = output.Replace(" .", ".");
            output = output.Replace(" ?", "?");
            output = output.Replace(" !", "!");
            return output;
        }
        private void ApplyFormatToSelectedText(DocumentRange sourceSelectedRange)
        {
            DocumentRange targetSelectedRange = richEditControl.Document.Selection;

            richEditControl.BeginUpdate();
            SubDocument targetSubDocument = targetSelectedRange.BeginUpdateDocument();
            SubDocument subDocument = sourceSelectedRange.BeginUpdateDocument();

            DevExpress.XtraRichEdit.API.Native.CharacterProperties targetCharactersProperties = targetSubDocument.BeginUpdateCharacters(targetSelectedRange);
            DevExpress.XtraRichEdit.API.Native.CharacterProperties sourceCharactersProperties = subDocument.BeginUpdateCharacters(sourceSelectedRange);
            targetCharactersProperties.Assign(sourceCharactersProperties);
            subDocument.EndUpdateCharacters(sourceCharactersProperties);
            targetSubDocument.EndUpdateCharacters(targetCharactersProperties);

            DevExpress.XtraRichEdit.API.Native.ParagraphProperties targetParagraphProperties = targetSubDocument.BeginUpdateParagraphs(targetSelectedRange);
            DevExpress.XtraRichEdit.API.Native.ParagraphProperties sourceParagraphProperties = subDocument.BeginUpdateParagraphs(sourceSelectedRange);
            targetParagraphProperties.Assign(sourceParagraphProperties);
            subDocument.EndUpdateParagraphs(sourceParagraphProperties);
            targetSubDocument.EndUpdateParagraphs(targetParagraphProperties);

            sourceSelectedRange.EndUpdateDocument(subDocument);
            targetSelectedRange.EndUpdateDocument(targetSubDocument);
            richEditControl.EndUpdate();
        }
        private void SpellCorrect_ItemClick(object sender, ItemClickEventArgs e)
        {
            Document document = richEditControl.Document;

            CharacterProperties[] formatting = new CharacterProperties[9999];
            int countparagraph = document.Paragraphs.Count;

            for (int i = 0; i < countparagraph; i++)
            {
                string rtf = document.GetRtfText(document.Paragraphs[i].Range);
                Document subdoc = richEditControl1.Document;
                DocumentRange newRange = subdoc.InsertRtfText(subdoc.Range.End, rtf);
                ParagraphProperties targetParagraphProperties = subdoc.BeginUpdateParagraphs(newRange);
                ParagraphProperties sourceParagraphProperties = document.BeginUpdateParagraphs(document.Paragraphs[i].Range);
                targetParagraphProperties.Assign(sourceParagraphProperties);
                document.EndUpdateParagraphs(sourceParagraphProperties);
                subdoc.EndUpdateParagraphs(targetParagraphProperties);
                string rft = subdoc.GetRtfText(newRange);

                string content = document.GetText(document.Paragraphs[i].Range);
                if (i == countparagraph - 1)
                    document.Replace(document.Paragraphs[i].Range, AutoCorrect(content));
                else document.Replace(document.Paragraphs[i].Range, AutoCorrect(content) + "\n");
                rft = document.GetRtfText(document.Paragraphs[i].Range);
                richEditControl.Document.Selection = document.Paragraphs[i].Range;

                ApplyFormatToSelectedText(newRange);
            }
        }

        private void SendDataFunc_ItemClick(object sender, ItemClickEventArgs e)
        {
            Document document = richEditControl.Document;
            pubRtf = document.GetRtfText(document.Range);
            if (room1.connectGetSet == false)
            {
                return;
            }
            room1.myConnectRoomGetSet.SendData(pubRtf);
        }
    }
}
