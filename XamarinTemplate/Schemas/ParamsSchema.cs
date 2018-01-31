using System;
namespace XamarinTemplate.Schemas {
    
    public class ParamsSchema {
        
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Data { get; set; }

        // กำหนดค่าเริ่มต้น
        public ParamsSchema () { }

    }

}
