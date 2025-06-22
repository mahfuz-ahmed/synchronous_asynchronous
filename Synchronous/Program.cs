
using Synchronous;

//SynchronousClass synchronousClass = new SynchronousClass();
//synchronousClass.SynchronousMethod(1);

var asyncClass = new ASynchronousFirstEX();
await asyncClass.ASynchronousMethod();

Console.WriteLine("Program End");