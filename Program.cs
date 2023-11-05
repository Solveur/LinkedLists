namespace LinkedLists
{
	internal partial class Program
	{
		static void Main(string[] args)
		{

		}

		void DeleteNode(ListNode node)
		{
			node.Next = node.Next.Next;
			node.Value = node.Next.Value;
		}
	}
}
