

public class Test {
	
	private void Start() {
		FunctionTimer.Create(()=> {
			Debug.Log("Do Something after 3 seconds");
		}, 3f);	
	}
	
	
}