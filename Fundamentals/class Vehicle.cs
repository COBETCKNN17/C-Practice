class Vehicle
{
    public string ColorProp
    {
        get
        {
    	    // Simply referencing the property will invoke the "getter", such as:
    	    // Console.WriteLine(vehicleObject.ColorProp);
    	    // and will return the following:
    
            return $"This thing is {Color}";
        }
        set
        {
    	    // Assigning a value to a property, such as:
    	    // vehicleObject.ColorProp = "Blue";
    	    // will invoke the "setter", and the "value" keyword will become the assigned value
    	    // ("Blue" in this example)
    
            Color = value;
        }
    }
}
