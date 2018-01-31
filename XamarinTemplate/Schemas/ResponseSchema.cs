using System;

namespace XamarinTemplate.Schemas {

    public class ResponseSchema {
        
        public string field01 { get; set; }
        public string field02 { get; set; }
        public string field03 { get; set; }

        // Defauft
        public ResponseSchema () {

            this.field01 = "";
            this.field02 = "";
            this.field03 = "";

        }

    }

}