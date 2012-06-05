using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;


public class Ebay {

	#region [ Proprietà ]

	private string _Title;
	public string Title {
		get { return _Title; }
		set { _Title = value; } 
	}

	private string _Description;
	public string Description {
		get { return _Description; }
		set { _Description = value; } 
	}

	private string _PrimaryCategory_categoryID;
	public string PrimaryCategory_categoryID {
		get { return _PrimaryCategory_categoryID; }
		set { _PrimaryCategory_categoryID = value; } 
	}

	private string _StartPrice_amount;
	public string StartPrice_amount {
		get { return _StartPrice_amount; }
		set { _StartPrice_amount = value; } 
	}

	private string _StartPrice_currencyID;
	public string StartPrice_currencyID {
		get { return _StartPrice_currencyID; }
		set { _StartPrice_currencyID = value; } 
	}

	private string _CategoryMappingAllowed;
	public string CategoryMappingAllowed {
		get { return _CategoryMappingAllowed; }
		set { _CategoryMappingAllowed = value; } 
	}

	private string _ConditionID;
	public string ConditionID {
		get { return _ConditionID; }
		set { _ConditionID = value; } 
	}

	private string _Country;
	public string Country {
		get { return _Country; }
		set { _Country = value; } 
	}

	private string _Currency;
	public string Currency {
		get { return _Currency; }
		set { _Currency = value; } 
	}

	private string _DispatchTimeMax;
	public string DispatchTimeMax {
		get { return _DispatchTimeMax; }
		set { _DispatchTimeMax = value; } 
	}

	private string _ListingDuration;
	public string ListingDuration {
		get { return _ListingDuration; }
		set { _ListingDuration = value; } 
	}

	private string _ListingType;
	public string ListingType {
		get { return _ListingType; }
		set { _ListingType = value; } 
	}

	private string _PaymentsMethods;
	public string PaymentsMethods {
		get { return _PaymentsMethods; }
		set { _PaymentsMethods = value; } 
	}

	private string _PayPalEmailAddress;
	public string PayPalEmailAddress {
		get { return _PayPalEmailAddress; }
		set { _PayPalEmailAddress = value; } 
	}

	private string _PictureDetails_galleryType;
	public string PictureDetails_galleryType {
		get { return _PictureDetails_galleryType; }
		set { _PictureDetails_galleryType = value; } 
	}

	private string _PostalCode;
	public string PostalCode {
		get { return _PostalCode; }
		set { _PostalCode = value; } 
	}

	private string _ProductListingDetails_UPC;
	public string ProductListingDetails_UPC {
		get { return _ProductListingDetails_UPC; }
		set { _ProductListingDetails_UPC = value; } 
	}

	private string _ProductListingDetails_includeStockPhotoURL;
	public string ProductListingDetails_includeStockPhotoURL {
		get { return _ProductListingDetails_includeStockPhotoURL; }
		set { _ProductListingDetails_includeStockPhotoURL = value; } 
	}

	private string _ProductListingDetails_includePrefilledItemInformation;
	public string ProductListingDetails_includePrefilledItemInformation {
		get { return _ProductListingDetails_includePrefilledItemInformation; }
		set { _ProductListingDetails_includePrefilledItemInformation = value; } 
	}

	private string _ProductListingDetails_useFirstProduct;
	public string ProductListingDetails_useFirstProduct {
		get { return _ProductListingDetails_useFirstProduct; }
		set { _ProductListingDetails_useFirstProduct = value; } 
	}

	private string _ProductListingDetails_useStockPhotoURLAsGallery;
	public string ProductListingDetails_useStockPhotoURLAsGallery {
		get { return _ProductListingDetails_useStockPhotoURLAsGallery; }
		set { _ProductListingDetails_useStockPhotoURLAsGallery = value; } 
	}

	private string _ProductListingDetails_returnSearchResultOnDuplicates;
	public string ProductListingDetails_returnSearchResultOnDuplicates {
		get { return _ProductListingDetails_returnSearchResultOnDuplicates; }
		set { _ProductListingDetails_returnSearchResultOnDuplicates = value; } 
	}

	private string _Quantity;
	public string Quantity {
		get { return _Quantity; }
		set { _Quantity = value; } 
	}

	private string _ReturnPolicy_returnsAcceptedOption;
	public string ReturnPolicy_returnsAcceptedOption {
		get { return _ReturnPolicy_returnsAcceptedOption; }
		set { _ReturnPolicy_returnsAcceptedOption = value; } 
	}

	private string _ReturnPolicy_refundOption;
	public string ReturnPolicy_refundOption {
		get { return _ReturnPolicy_refundOption; }
		set { _ReturnPolicy_refundOption = value; } 
	}

	private string _ReturnPolicy_returnsWithinOption;
	public string ReturnPolicy_returnsWithinOption {
		get { return _ReturnPolicy_returnsWithinOption; }
		set { _ReturnPolicy_returnsWithinOption = value; } 
	}

	private string _ReturnPolicy_description;
	public string ReturnPolicy_description {
		get { return _ReturnPolicy_description; }
		set { _ReturnPolicy_description = value; } 
	}

	private string _ReturnPolicy_shippingCostPaidByOption;
	public string ReturnPolicy_shippingCostPaidByOption {
		get { return _ReturnPolicy_shippingCostPaidByOption; }
		set { _ReturnPolicy_shippingCostPaidByOption = value; } 
	}

	private string _SD_shippingType;
	public string SD_shippingType {
		get { return _SD_shippingType; }
		set { _SD_shippingType = value; } 
	}

	private string _SD_shippingServiceOptions;
	public string SD_shippingServiceOptions {
		get { return _SD_shippingServiceOptions; }
		set { _SD_shippingServiceOptions = value; } 
	}

	private string _Site;
	public string Site {
		get { return _Site; }
		set { _Site = value; } 
	}

	private string _StoreCategoryID;
	public string StoreCategoryID {
		get { return _StoreCategoryID; }
		set { _StoreCategoryID = value; } 
	}

	private string _StoreCategory2ID;
	public string StoreCategory2ID {
		get { return _StoreCategory2ID; }
		set { _StoreCategory2ID = value; } 
	}

	private string _ItemID;
	public string ItemID {
		get { return _ItemID; }
		set { _ItemID = value; } 
	}

	private string _Ean;
	public string Ean {
		get { return _Ean; }
		set { _Ean = value; } 
	}

	private string _Variato;
	public string Variato {
		get { return _Variato; }
		set { _Variato = value; } 
	}

	private string _NotInListing;
	public string NotInListing {
		get { return _NotInListing; }
		set { _NotInListing = value; } 
	}

	private string _CancellatoDaEbay;
	public string CancellatoDaEbay {
		get { return _CancellatoDaEbay; }
		set { _CancellatoDaEbay = value; } 
	}

	private string _Classificazione_origine;
	public string Classificazione_origine {
		get { return _Classificazione_origine; }
		set { _Classificazione_origine = value; } 
	}

	private string _Bloccato;
	public string Bloccato {
		get { return _Bloccato; }
		set { _Bloccato = value; } 
	}

	private string _InfoDaScaricare;
	public string InfoDaScaricare {
		get { return _InfoDaScaricare; }
		set { _InfoDaScaricare = value; } 
	}

	#endregion
}
