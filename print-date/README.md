# Goal
Be able to test printCurrentDate function without changing the method signature.

1. Test the code with doubles using a library.
2. Test the code with doubles created by you.

# Code to test
    public void PrintCurrentDate()
    {
        var line = _calendar.Today().ToString();
        _printer.PrintLine(line);
    }

### Example of Mock/Spy

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

## Authors
Luis Rovirosa [@luisrovirosa](https://www.twitter.com/luisrovirosa)

Jordi Anguela [@jordianguela](https://www.twitter.com/jordianguela)
