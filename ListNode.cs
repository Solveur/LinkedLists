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
			public ListNode(int value, ListNode next)
			{
				Value = value;
				Next = next;
			}
			public ListNode(int[] input)
			{
				Value = input[0];
				for (int i = 1; i < input.Length; i++)
				{
					Append(input[i]);
				}
			}

			public void Append(int x)
			{
				var a = Last().Next = new();
				a.Value = x;
			}

			public ListNode Last()
			{
				ListNode last = this;

				while (last.Next != null)
				{
					last = last.Next;
				}

				return last;
			}

			public int Count()
			{
				ListNode ptr = this;
				int count = 0;

				while (ptr.Next != null)
				{
					ptr = ptr.Next;
					count++;
				}

				return count;
			}

			public ListNode PreLast()
			{
				ListNode last = this;

				while (last.Next.Next != null)
				{
					last = last.Next;
				}

				return last;
			}

			public void Print()
			{
				ListNode node = this;

				while (node != null)
				{
					Console.Write($"{node.Value,3},");
					node = node.Next;
				}

				Console.WriteLine();
			}
		}
	}
}
