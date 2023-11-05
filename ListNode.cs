namespace LinkedLists
{
	using System.Collections.Generic;

	internal partial class Program
	{
		class ListNode
		{
			public ListNode? Next { get; set; }
			public int? Value { get; set; }

			public ListNode()	{	}

			public ListNode(IEnumerable<int> input)
			{
				ListNode pointer = this;
				foreach (var element in input)
				{
					pointer.Value = element;
					pointer.Next = new();
					pointer = pointer.Next;
				}
			}

			public void Print()
			{
				ListNode node = this;

				while (node.Next != null)
				{
					Console.Write($"{node.Value,-3}");
					node = node.Next;
				}

				Console.WriteLine();
			}
		}
	}
}
