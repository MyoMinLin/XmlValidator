namespace XmlValidator
{
    public class Validator
    {
        public static bool DetermineXml(string xml)
        {
            if (!xml.Contains('<')) return false;

            var xmlTags = new Stack<string>();
            int index = 0;

            if (xml.StartsWith("<?xml"))
            {
                int xmlTagIndex = xml.IndexOf("?>") + 1;
                xml = xml[xmlTagIndex..].TrimStart();
            }

            while (index < xml.Length)
            {
                // Ignore comment 
                if (xml[index] == '<' &&
                    index + 3 < xml.Length &&
                    xml.Substring(index, 4) == "<!--")
                {
                    int commentEndIndex = xml.IndexOf("-->", index + 4);

                    if (commentEndIndex == -1)
                        return false;

                    index = commentEndIndex + 3;
                }
                else if (xml[index] == '<')
                {
                    int closingIndex = xml.IndexOf('>', index + 1);

                    if (closingIndex == -1)
                        return false;

                    string tag = xml.Substring(index + 1, closingIndex - index - 1);

                    if (tag.StartsWith("/"))
                    {
                        if (xmlTags.Count == 0 || xmlTags.Pop() != tag[1..])
                            return false;
                    }
                    else
                    {
                        xmlTags.Push(tag);
                    }

                    index = closingIndex + 1;
                }
                else
                {
                    index++;
                }
            }

            return xmlTags.Count == 0;
        }
    }
}