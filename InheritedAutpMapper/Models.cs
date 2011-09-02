namespace InheritedAutoMapper
{
    public class SourceBaseClass
    {
        public string BaseProp1 { get; set; }
        public string BaseProp2 { get; set; }
    }

    public class SourceChildClass : SourceBaseClass
    {
        public string ChildProp1 { get; set; }
        public string ChildProp2 { get; set; }
    }

    public class DestBaseClass
    {
        public string BaseProp1 { get; set; }
        public string BasePropTwo { get; set; }
    }

    public class DestChildClass : DestBaseClass
    {
        public string ChildProp1 { get; set; }
        public string ChildPropTwo { get; set; }
    }
}