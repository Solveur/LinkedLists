namespace LinkedLists
{
	internal partial class Program
	{
		static void Main(string[] args)
		{
			ListNode list = new([1, 2, 3, 4, 5]);
			list.Print();
			ListNode? toDelete = list.Next;
			DeleteNode(toDelete);
			list.Print();
		}

		ListNode Merge(ListNode list1, ListNode list2)
		{

			return new();
		}

		// 5
		static void DeleteNode(ListNode? node)
		{
			if (node == null)
				return;

			node.Value = node.Next?.Value;
			node.Next = node.Next?.Next;
		}
	}
}
