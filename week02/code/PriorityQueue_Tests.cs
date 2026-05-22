using System.IO.Pipelines;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Happy path priority queue
    // Expected Result: ["Tim","Sue","Bob"]
    // Defect(s) Found: Dequeue does not remove the item and returns the same item repeatedly. Additionally the loop skips the last item of the list
    public void TestPriorityQueue_1()
    {
        String[] expectedResult = ["Tim", "Sue", "Bob"];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Bob", 2);
        priorityQueue.Enqueue("Tim", 5);
        priorityQueue.Enqueue("Sue", 3);


        for (int i = 0; i < expectedResult.Length; i++)
        {
            string result = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i], result);
        }
    }

    [TestMethod]
    // Scenario: Shared priority queue
    // Expected Result: ["Tim","Jack","Sue","Bob"]
    // Defect(s) Found: >= when finding the highest priority item to remove causes last-in, first out behavior
    public void TestPriorityQueue_2()
    {
        String[] expectedResult = ["Tim", "Jack", "Sue", "Bob"];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Bob", 2);
        priorityQueue.Enqueue("Tim", 5);
        priorityQueue.Enqueue("Sue", 3);
        priorityQueue.Enqueue("Jack", 5);


        for (int i = 0; i < expectedResult.Length; i++)
        {
            string result = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i], result);
        }
    }

    [TestMethod]
    // Scenario: Shared priority queue
    // Expected Result: ["Tim","Jack","Sue","Bob"]
    // Defect(s) Found: None
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }
}