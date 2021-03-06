//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AR.Eftpos.Provider.PaymentIntegration {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("AR.Eftpos.Provider.PaymentIntegration.Resource", typeof(Resource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to VNPAY Card/ Quẹt thẻ ngân hàng.
        /// </summary>
        internal static string BankCardHeader {
            get {
                return ResourceManager.GetString("BankCardHeader", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Swipe debit/credit from SPOS to complete transaction/ Quẹt thẻ ghi nợ/ tín dụng để thanh toán.
        /// </summary>
        internal static string BankCardSubTitle {
            get {
                return ResourceManager.GetString("BankCardSubTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Initialize successfully/ Khởi tạo giao dịch thành công.
        /// </summary>
        internal static string InitSuccess {
            get {
                return ResourceManager.GetString("InitSuccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Không nhận được kết quả giao dịch từ VNPay. 
        ///Thử lại hoặc chọn &apos;Manual Update&apos; nếu kết quả trên SPOS là thành công..
        /// </summary>
        internal static string ManualUpdate {
            get {
                return ResourceManager.GetString("ManualUpdate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to VNPAY QR/ Quét mã QR.
        /// </summary>
        internal static string QRHeader {
            get {
                return ResourceManager.GetString("QRHeader", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Scan QR code from SPOS to complete transaction/ Quét mã QR để thanh toán.
        /// </summary>
        internal static string QRSubTitle {
            get {
                return ResourceManager.GetString("QRSubTitle", resourceCulture);
            }
        }
    }
}
