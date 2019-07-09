﻿using Nop.Core;

namespace Nop.Plugin.Payments.Square
{
    /// <summary>
    /// Represents plugin constants
    /// </summary>
    public class SquarePaymentDefaults
    {
        /// <summary>
        /// Name of the view component to display plugin in public store
        /// </summary>
        public const string VIEW_COMPONENT_NAME = "PaymentSquare";

        /// <summary>
        /// Square payment method system name
        /// </summary>
        public static string SystemName => "Payments.Square";

        /// <summary>
        /// User agent used to request Square services
        /// </summary>
        public static string UserAgent => $"nopCommerce-{NopVersion.CurrentVersion}";

        /// <summary>
        /// The Integration ID should be added in the charge endpoint in order to correctly track the profit generated by the merchants using the Square payment plugin
        /// </summary>
        public static string IntegrationId => "sqi_4efb0346e2ef4b1375319dcd6e9977c0";

        /// <summary>
        /// One page checkout route name
        /// </summary>
        public static string OnePageCheckoutRouteName => "CheckoutOnePage";

        /// <summary>
        /// Path to the Square payment form js script
        /// </summary>
        public static string PaymentFormScriptPath => "https://js.squareup.com/v2/paymentform";

        /// <summary>
        /// Key of the attribute to store Square customer identifier
        /// </summary>
        public static string CustomerIdAttribute => "SquareCustomerId";

        /// <summary>
        /// Name of the route to the access token callback
        /// </summary>
        public static string AccessTokenRoute => "Plugin.Payments.Square.AccessToken";

        /// <summary>
        /// Name of the renew access token schedule task
        /// </summary>
        public static string RenewAccessTokenTaskName => "Renew access token (Square payment)";

        /// <summary>
        /// Type of the renew access token schedule task
        /// </summary>
        public static string RenewAccessTokenTask => "Nop.Plugin.Payments.Square.Services.RenewAccessTokenTask";

        /// <summary>
        /// Default access token renewal period in days
        /// </summary>
        public static int AccessTokenRenewalPeriodRecommended => 14;

        /// <summary>
        /// Max access token renewal period in days
        /// </summary>
        public static int AccessTokenRenewalPeriodMax => 30;

        /// <summary>
        /// Sandbox credentials should start with this prefix
        /// </summary>
        public static string SandboxCredentialsPrefix => "sandbox-";

        /// <summary>
        /// Note passed for each payment transaction
        /// </summary>
        /// <remarks>
        /// {0} : Order Guid
        /// </remarks>
        public static string PaymentNote => "nopCommerce: {0}";
    }
}