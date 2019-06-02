#pragma checksum "c:\Users\MiiNRea\Desktop\sproject\Views\PurchaseOrder\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4273be06535bb0d02df2e04aeecfb4391cd1b78f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PurchaseOrder_Create), @"mvc.1.0.view", @"/Views/PurchaseOrder/Create.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/PurchaseOrder/Create.cshtml", typeof(AspNetCore.Views_PurchaseOrder_Create))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "c:\Users\MiiNRea\Desktop\sproject\Views\_ViewImports.cshtml"
using sproject;

#line default
#line hidden
#line 2 "c:\Users\MiiNRea\Desktop\sproject\Views\_ViewImports.cshtml"
using sproject.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4273be06535bb0d02df2e04aeecfb4391cd1b78f", @"/Views/PurchaseOrder/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb6db91a464338634b626bcf055f7479d45db7f3", @"/Views/_ViewImports.cshtml")]
    public class Views_PurchaseOrder_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2022, true);
            WriteLiteral(@" <h4>Create New Purchase Order</h4>
 <hr />
 <div class=""row"">
     <div class=""col-md-6"">
         <div class=""form-group"">
             <label class=""control-label"">product </label>
             <select class=""form-group"" id=""product_names"" ></select>
         </div>
         <div class=""form-group"">
             <label class=""control-label"">supplier </label>
             <select class=""form-group"" id=""supplier_names"" ></select>
         </div>
        <h5>Product info</h5>
         <table class=""table"" id=""table2"">
             <tr>
                 <th>Product id</th>
                 <th>Product name</th>
                 <th>series</th>
                 <th>size</th>
             </tr>
         </table>
           <!-- <div class=""form-group"">
             <label class=""control-label"">purchase order type</label>
             <select id=""purchase_type"" >
                 <option value=""1"">press</option>
                 <option value=""2"">back order</option>
                 <opt");
            WriteLiteral(@"ion value=""3"">complete</option>
             </select>
         </div> -->
         <div class=""form-group"">
             Price    <input class=""form-control"" id=""txt_price"" />
         </div>
         <div class=""form-group"">
             Quantity <input class=""form-control"" id=""txt_qty""/>
             <button id=""cmd_inc"">+</button>
             <button id=""cmd_dec"">-</button>
         </div>
         <div class=""form-group"">
             <button id=""cmd_add"">add</button>
         </div>

         <table class=""table"" id=""table1"">
             <tr>
                 <th>Product id</th>
                 <th>Product name</th>
                 <th>Supplier name</th>
                 <th>Quantity</th>
                 <th>Cost</th>
                 <th>Total</th>
                 <th>Selling price</th>
                 <th>Operation</th>
             </tr>
         </table>
         <button id=""cmd_confirm"">confirm</button>
     </div>
 </div>
 <div>
     ");
            EndContext();
            BeginContext(2022, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4273be06535bb0d02df2e04aeecfb4391cd1b78f5589", async() => {
                BeginContext(2044, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2060, 13, true);
            WriteLiteral("\r\n </div>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2091, 7763, true);
                WriteLiteral(@"
 <script>
     var list = [];
     var cart = [];

     var show = [];

     var cmb_product_names = $('#product_names');
     var cmb_supplier_names = $('#supplier_names');
     var txt_qty = $('#txt_qty');
     var txt_price = $('#txt_price');
     var tbl_table2 = $('#table2');
     var tbl_table1 = $('#table1');
     var cmd_inc = $('#cmd_inc');
     var cmd_dec = $('#cmd_dec');
     var cmd_add = $('#cmd_add');
     var cmd_confirm = $('#cmd_confirm');

     $(document).ready(cb); //register callback function to service document ready event


     function cb() {

         //register combobox event
         cmb_product_names.change(cb_product_names_change);
         cmb_supplier_names.change(cb_show_productinfo);

         cmd_inc.click(cb_inc_clicked);
         cmd_dec.click(cb_dec_clicked);
         cmd_add.click(cb_add_clicked);
         cmd_confirm.click(cb_confirm_clicked);

         $.get(""/productinfo/products"", product_data_arrived);
     } //end cb

     funct");
                WriteLiteral(@"ion cb_confirm_clicked() {

         var result = [];
         for (var i = 0; i < cart.length; i++) {
             result.push(cart[i]);
         }
         var out_data= {
             purchase_type_id :10,
             items: result
         };

         console.log(""tag1"",out_data);
         //step30: post operation
         option = {
             // dataType: ""json"",
             type: 'POST',
            // data: {
            //     items: result
            // },
            data:{
                cart: out_data
            },
             url: '/purchaseorder/create',
             success: addcart_done,
             error: function (err) {
                 console.log('error', err);
             }
         };
         $.post(option);
     }
     //step33: data return from the server side
     function addcart_done(data) {
         window.location.replace(data.newUrl); //redirect to Index Action
     }

     function cb_removes_clicked(obj) {
         //console.log");
                WriteLiteral(@"($(this).val());
         var product_id = $(obj).attr('data-id');
         cart = cart.filter((a) => {
             return a.id != product_id
         });
         console.log(cart);
         updateTable();
     }

     function cb_inc_clicked() {

         var value = parseInt(txt_qty.val());
         value++;
         txt_qty.val(value.toString());
     }

     function cb_dec_clicked() {

         var value = parseInt(txt_qty.val());
         value--;
         if (value == 0) {
             value = 1;
         }
         txt_qty.val(value.toString());
     }

     function cb_add_clicked() {
         var target_product_name    = cmb_product_names.val();
         var target_supplier_id     = cmb_supplier_names.val();
        
         var found = list.find(function(x){
                return x.product_name   == target_product_name &&
                       x.supplier_id    == target_supplier_id;
         });
         console.log(found);
         var product_id = found.pro");
                WriteLiteral(@"duct_id;
         var price = parseFloat(txt_price.val());
         var qty = parseInt(txt_qty.val());
         var selling_price = parseFloat(); 
         var ben = 1.30;
         var total = price * qty ;

       
         var row = {
             id     : found.product_id,
             supplier_id: found.supplier_id,
             supplier_name : found.supplier_name,
             name   : found.product_name,
             price  : price,
             qty    : qty,
             total  : price * qty,
             selling_price : total*ben
             
         };
         cart.push(row);
         updateTable();
     }

     function tr(data) {
         return '<tr>' + data + '</tr>';
     }

     function td(data) {
         return '<td>' + data + '</td>';
     }

     function button(id, data) {
         return '<button  onclick=""cb_removes_clicked(this)"" data-id=""' + id + '"">' + data + '</button>';
     }

     function updateTable() {
         //remove all rows except th");
                WriteLiteral(@"e header row
         tbl_table1.find(""tr:gt(0)"").remove();
         var total = 0;
         var selling_price = 0;
         for (var i = 0; i < cart.length; i++) {
             var row = tr(td(cart[i].id)+td(cart[i].name) + td(cart[i].supplier_name)+ td(cart[i].qty) + td(cart[i].price) + td(cart[i].total) + td(cart[i].selling_price)+ td(button(cart[i]
                 .id, ""remove"")));
             tbl_table1.append(row);
             total += cart[i].price * cart[i].qty;
             selling_price += (cart[i].price * cart[i].qty)*1.3;
         }
         var summary = tr(td('total') + td('') + td('') + td('') + td('') + td(total) +td(selling_price));
         tbl_table1.append(summary);

     }

     //product data arrived from server
     function product_data_arrived(data) {
         console.log('yes'); 
         list = data; //update list with data from server

         //find unique product name
         var unique_product_names = [...new Set(list.map(x => x.product_name))];

   ");
                WriteLiteral(@"      $.each(unique_product_names, function (key, item) {
             cmb_product_names.append('<option value=' + item + '>' + item + '</option>');
         });
        if(list.length>0){
             var id = list[0].product_id;
            
             var url = ""/supplierInfo/suppliers?id=""+id;
             console.log(url);
            $.get(url, cb_product_names_change);
         }
         $.get(""/productInfo/products"", cb_show_productinfo);
         txt_qty.val(""1"");
    } //ef

     function cb_product_names_change() {
       
         //get selection value
         var product_name = cmb_product_names.val();
       
         //search object in the list by product_id
         var founds = list.filter((a) => {
             return a.product_name == product_name
         });

         //update product price in txt price textbox
         console.log(founds);
         if (founds != null) {
             cmb_supplier_names.empty();
             $.each(founds, function (key, item");
                WriteLiteral(@") {
                 cmb_supplier_names.append('<option value=' + item.supplier_id + '>' + item.supplier_name + '</option>');
             }); 
             //update table with supplier in the combobo->cmb_supplier_names
             
             cb_show_productinfo();
        }
    }

    function cb_show_productinfo(){
        var p_name = cmb_product_names.val();
        var s_name = cmb_supplier_names.val();
        //$.get(""/productinfo/products"");
        var found2 = list.find(function(b){
                return b.product_name   == p_name &&
                       b.supplier_id    == s_name;
         });
         
         console.log(found2);
         var product_id = found2.product_id;
         var product_name = found2.product_name;
         var product_series = found2.product_series;
         var product_size = found2.product_size;

         var row2 = {
             id : found2.product_id,
             product_name : found2.product_name,
             product_series : fo");
                WriteLiteral(@"und2.product_series,
             product_size : found2.product_size
         };
        show = []; //clear show list
        show.push(row2);
        showtable();
    }
        function showtable(){
         //remove all rows except the header row
         tbl_table2.find(""tr:gt(0)"").remove();
         //tbl_table2.empty();
         for(var j = 0; j < show.length; j++) {
             var row2 = tr(td(show[j].id)+td(show[j].product_name) + td(show[j].product_series)+ td(show[j].product_size));
             tbl_table2.append(row2)
        }
        
    }    
 </script>
 ");
                EndContext();
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
