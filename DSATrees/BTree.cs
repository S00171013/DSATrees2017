using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSATrees
{
    public class ConversationTree
    {
        public ConversationNode root;

        public ConversationNode InsertAfter(ConversationNode current,
                        string phrase, string NextPhrase)
        {
            if (current.phrase == phrase)
            {
                // add the new Phrase to the childern
                ConversationNode child = new ConversationNode(NextPhrase, null);
                current.children.Add(child);
                return child;

            }
            else if (current.children.Count() > 0)
                foreach (ConversationNode node in current.children)
                    return InsertAfter(node, phrase, NextPhrase);

            return null;
        }
    }

    public class ConversationNode
    {
        public List<ConversationNode> children = new List<ConversationNode>();

            
        public string phrase;

        
        public ConversationNode(string Phrase,
                        List<string> childPhrases)
        {
            phrase = Phrase;
            if (childPhrases != null)
            {
                foreach (var p in childPhrases)
                {
                    children.Add(new ConversationNode(p, null));
                }
            }
        }

        
    }
}
