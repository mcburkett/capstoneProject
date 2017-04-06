#pragma strict


function Start () {

}
var forwardSpeed : float = 50;
var turnSpeed : float = 2;
function Update () {
	//forward speed
	var forwardMoveAmount = Input.GetAxis("Vertical")*forwardSpeed;

	//turn speed
	var turnAmount = Input.GetAxis("Horizontal")*turnSpeed;

	//rotates rover
	transform.Rotate(0,turnAmount,0);

	//pushes vehicle onward with force
	//GetComponent<Rigidbody>(-forwardMoveAmount,0,0);
	//rigidbody.AddForce(-forwardMoveAmount,0,0);
	//transform.GetComponent<Rigidbody> (0,0,0)
	//add.RelativeForce(-forwardMoveAmount,0,0);
	GetComponent.<Rigidbody>().AddForce(-forwardMoveAmount,0,0);
	//GetComponent.<Rigidbody>().AddRelativeForce(-forwardMoveAmount,0,0);
}