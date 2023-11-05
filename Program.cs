namespace LinkedLists
{
	internal partial class Program
	{
		static void Main(string[] args)
		{
			ListNode list = new([1, 2, 3, 4, 5]);
			Double(list).Print();
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
		static ListNode DeleteDuplicates(ListNode head)
		{
			if (head == null)
				return head;

			ListNode node = head;
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
			return head;
		}

		// 3
		bool IsCyclic(ListNode head)
		{
			ListNode turtle = head;
			ListNode rabbit = head;

			while (rabbit != null || rabbit.Next != null)
			{
				turtle = turtle.Next;
				rabbit = rabbit.Next.Next;
				if (turtle == rabbit) return true;
			}

			return false;
		}

		// 4
		static ListNode ReorderList(ListNode head)
		{
			ListNode slow = head;
			ListNode fast = head.Next;

			while (fast != null && fast.Next != null)
			{
				fast = fast.Next.Next;
				slow = slow.Next;
			}

			ListNode right = slow.Next;
			ListNode left = head;
			slow.Next = null;

			ListNode previous = null;
			ListNode current = right;
			while (current != null)
			{
				ListNode next = current.Next;
				current.Next = previous;
				previous = current;
				current = next;
			}

			right = previous;

			while (right != null)
			{
				ListNode leftTemp = left.Next;
				ListNode rightTemp = right.Next;
				left.Next = right;
				right.Next = leftTemp;

				left = leftTemp;
				right = rightTemp;
			}

			return head;
		}

		// 5
		static void DeleteNode(ListNode node)
		{
			if (node == null)
				return;

			node.Value = node.Next?.Value;
			node.Next = node.Next?.Next;
		}

		// 6 
		static ListNode Double(ListNode head)
		{
			ListNode currentNode = head;
			ListNode previousNode = null;

			if (currentNode.Value * 2 > 9)
			{
				previousNode = new ListNode(0, currentNode);
				head = previousNode;
			}

			while (currentNode != null)
			{
				currentNode.Value *= 2;

				if (currentNode.Value > 9)
				{
					previousNode.Value += 1;
					currentNode.Value %= 10;
				}

				previousNode = currentNode;
				currentNode = currentNode.Next;
			}

			return head;
		}

		// 7
		static ListNode MergeK(ListNode[] lists)
		{
			if (lists == null || lists.Length == 0)
			{
				return null;
			}

			ListNode result = lists[0];

			for (var i = 1; i < lists.Length; i++)
			{
				result = Merge(result, lists[i]);
			}

			return result;
		}

		// 8 
		static ListNode ReverseKGroup(ListNode head, int k)
		{
			ListNode dummy = new ListNode(0, head);
			ListNode cur = head;
			ListNode tail = dummy;
			while (cur != null)
			{
				int i = k;
				while (cur != null && i > 0)
				{
					cur = cur.Next;
					i--;
				}

				if (i > 0)
				{
					continue;
				}

				(ListNode newHead, ListNode newTail) = reverseList(head, k);
				tail.Next = newHead;
				newTail.Next = cur;
				tail = newTail;
				head = cur;
			}

			return dummy.Next;
		}

		private static (ListNode, ListNode) reverseList(ListNode cur, int k)
		{
			ListNode prev = null;
			ListNode tail = cur;

			while (cur != null && k > 0)
			{
				ListNode next = cur.Next;
				cur.Next = prev;
				prev = cur;
				cur = next;
				k--;
			}

			return (prev, tail);
		}

		// 9
		static ListNode[] Split(ListNode head, int k)
		{
			int count = 0;
			ListNode current = head;
			while (current != null)
			{
				count++;
				current = current.Next;
			}

			int partSize = count / k;
			int extraNodes = count % k;

			ListNode[] result = new ListNode[k];
			current = head;

			for (int i = 0; i < k; i++)
			{
				result[i] = current;

				int currentPartSize = partSize + (extraNodes > 0 ? 1 : 0);

				for (int j = 0; j < currentPartSize - 1; j++)
				{
					if (current != null)
					{
						current = current.Next;
					}
				}

				if (extraNodes > 0)
				{
					extraNodes--;
				}

				if (current != null)
				{
					ListNode temp = current.Next;
					current.Next = null;
					current = temp;
				}
			}

			return result;
		}
	}
}
