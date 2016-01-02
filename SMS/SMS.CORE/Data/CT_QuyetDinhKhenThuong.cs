﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace SMS.CORE.Data
{
    [Table("CT_QuyetDinhKhenThuong")]
    public partial class CT_QuyetDinhKhenThuong
    {
        [Key, StringLength(50), Column(Order=0, TypeName="varchar")]
        public string SoQuyetDinh { get; set; }

        [Key, StringLength(50), Column(Order=1, TypeName="varchar")]
        public string MaHocSinh { get; set; }

        [Required, StringLength(200)]
        public string LyDoKhenThuong { get; set; }

        [Required, StringLength(200)]
        public string HinhThucKhenThuong { get; set; }

        public long? GiaTriKhenThuong { get; set; }

        [Required]
        public bool GhiVaoHocBa { get; set; }

        public virtual QuyetDinhKhenThuong QDKhenThuong { get; set; }
        public virtual HocSinh HocSinh { get; set; }
    }
}
