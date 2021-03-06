﻿using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace Npoi.Core.OpenXmlFormats.Wordprocessing
{
    public class CommentsDocument
    {
        private CT_Comments comments = null;

        public CommentsDocument()
        {
            comments = new CT_Comments();
        }

        public static CommentsDocument Parse(XDocument doc, XmlNamespaceManager NameSpaceManager)
        {
            CT_Comments obj = CT_Comments.Parse(doc.Document.Root, NameSpaceManager);
            return new CommentsDocument(obj);
        }

        public CommentsDocument(CT_Comments comments)
        {
            this.comments = comments;
        }

        public CT_Comments Comments
        {
            get
            {
                return this.comments;
            }
        }

        public void Save(Stream stream)
        {
            using (StreamWriter sw = new StreamWriter(stream))
            {
                comments.Write(sw);
            }
        }
    }
}