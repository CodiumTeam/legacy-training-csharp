# Goal
Be able to test printCurrentDate function.
# Code to test
    public void PrintCurrentDate()
    {
      Console.WriteLine(DateTime.Now);
    }

### Example of Mock

	[Fact]
	public void should_interact_with_the_mock() {
    	collaborator = Substitute.For<Collaborator>();       
    	MyClass myClass = new MyClass(collaborator);

    	myClass.Run();

    	collaborator.Received().Collaborate();
	}
### Example of Stub    

	[Fact]
	public void should_retrieve_the_stub_response(){
    	collaborator = Substitute.For<Collaborator>();
    	String response = "collaborator response";
    	calculator.Collaborate().Returns(response);
    	MyClass myClass = new MyClass(collaborator);

    	String result = myClass.Run();

    	Assert.Equal(response, result);
	}

# Learnings
- Dependency injection.
- How to build a Mock and Stub manually.
- How to use a mocking library.
