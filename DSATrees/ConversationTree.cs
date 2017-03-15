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

        public ConversationNode InsertAfter(string phrase, string NextPhrase)
        {
            ConversationNode found = Find(root, phrase);
            if (found!= null)
            {
                ConversationNode newNode = new ConversationNode(NextPhrase, null);
                found.children.Add(newNode);
                return newNode;
            }
            return null;
        }

        public ConversationNode Find(ConversationNode current, string Phrase)
        {
            if (current != null)
            {
                if (current.phrase == Phrase)
                {
                    return current;
                }
                else if (current.children.Count() > 0)
                    foreach (ConversationNode node in current.children)
                        if (node.phrase != Phrase)
                            current = Find(node, Phrase);
                        else return node;
            }
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
