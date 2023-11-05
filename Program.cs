namespace LinkedLists
{
	internal partial class Program
	{
		static void Main(string[] args)
		{

		}

		// 1
		static ListNode Merge(ListNode list1, ListNode list2)
		{
			ListNode resultHead = new()
			{
				Value = -1
			};
			ListNode resultPtr = resultHead;

			for (; list1 != null && list2 != null; resultPtr = resultPtr.Next)
			{
				if (list1.Value <= list2.Value)
				{
					resultPtr.Next = list1;
					list1 = list1.Next;
				}
				else
				{
					resultPtr.Next = list2;
					list2 = list2.Next;
				}
			}

			if (list1 != null)
				resultPtr.Next = list1;
			else
				resultPtr.Next = list2;

			return resultHead.Next;
		}

		// 2
		ListNode DeleteDuplicates(ListNode list)
		{
			if (list == null)
				return list;

			ListNode node = list;
			while (node.Next != null)
			{
				if (node.Value == node.Next.Value)
				{
					ListNode ptr = node.Next;
					node.Next = ptr.Next;
				}
				else
					node = node.Next;
			}
			return list;
		}

		// 3
		bool IsCyclic(ListNode list)
		{
			ListNode turtle = list;
			ListNode rabbit = list;

			while (rabbit != null || rabbit.Next != null)
			{
				turtle = turtle.Next;
				rabbit = rabbit.Next.Next;
				if (turtle == rabbit) return true;
			}

			return false;
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
