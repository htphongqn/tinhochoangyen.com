﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using vpro.functions;

namespace Controller
{
    public class Function
    {
        public string Getlink_News(object News_url, object Seo_url, object Cat_seo_url)
        {
            string _sType = Utils.CStrDef(Cat_seo_url);
            return string.IsNullOrEmpty(Utils.CStrDef(News_url)) ? "/" + _sType + "/" + Utils.CStrDef(Seo_url) + ".html" : Utils.CStrDef(News_url);
        }
        public string Getlink_Cat(object Cat_Url, object Cat_Seo_Url)
        {
            return string.IsNullOrEmpty(Utils.CStrDef(Cat_Url)) ? "/" + Utils.CStrDef(Cat_Seo_Url) + ".html" : Utils.CStrDef(Cat_Url);
        }
        public string Getprice(object Price)
        {
            decimal _dPrice = Utils.CDecDef(Price);
            return _dPrice != 0 ? String.Format("{0:0,0 VNĐ}",_dPrice) : "Liên hệ";
        }
        public string getDate(object News_PublishDate)
        {
            return string.Format("{0:dd/MM/yyyy}", News_PublishDate);
        }
        public string GetImageT_News(object News_Id, object News_Image1)
        {

            try
            {
                if (Utils.CIntDef(News_Id) > 0 && !string.IsNullOrEmpty(Utils.CStrDef(News_Image1)))
                {
                    return PathFiles.GetPathNews(Utils.CIntDef(News_Id)) + Utils.CStrDef(News_Image1);
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                return null;
            }
        }
        public string GetImageT_News_Hasclass(object News_Id, object News_Image1,string nameclass)
        {

            try
            {
                if (Utils.CIntDef(News_Id) > 0 && !string.IsNullOrEmpty(Utils.CStrDef(News_Image1)))
                {
                    return "<img class='"+nameclass+"' alt='' src='"+PathFiles.GetPathNews(Utils.CIntDef(News_Id)) + Utils.CStrDef(News_Image1)+"'/>";
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                return null;
            }
        }
        public string Getimages_Cat(object cat_id, object cat_img)
        {
            if (Utils.CIntDef(cat_id) > 0 && !string.IsNullOrEmpty(Utils.CStrDef(cat_img)))
            {
                return PathFiles.GetPathCategory(Utils.CIntDef(cat_id)) + Utils.CStrDef(cat_img);
            }
            else
            {
                return "";
            }
        }
        public string GetImageAd(object Ad_Id, object Ad_Image1, object Ad_Target, object Ad_Url)
        {
            try
            {
                if (Utils.CIntDef(Ad_Id) > 0 && !string.IsNullOrEmpty(Utils.CStrDef(Ad_Image1)))
                    return "<a href='" + Utils.CStrDef(Ad_Url) + "' target='" + Utils.CStrDef(Ad_Target) + "'><img  width='100%' src='" + PathFiles.GetPathAdItems(Utils.CIntDef(Ad_Id)) + Utils.CStrDef(Ad_Image1) + "' alt='' /></a>";
                return "";
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                return null;
            }

        }
        public string GetImageAd(object Ad_Id, object Ad_Image1, object Ad_Target, object Ad_Url, object type)
        {
            try
            {
                string _sResult = string.Empty;
                if (Utils.CIntDef(type) == 0)
                {

                    if (Utils.CIntDef(Ad_Id) > 0 && !string.IsNullOrEmpty(Utils.CStrDef(Ad_Image1)))
                        _sResult = "<a href='" + Utils.CStrDef(Ad_Url) + "' target='" + Utils.CStrDef(Ad_Target) + "'><img  width='100%' src='" + PathFiles.GetPathAdItems(Utils.CIntDef(Ad_Id)) + Utils.CStrDef(Ad_Image1) + "' alt='' /></a>";
                }
                else
                {
                    if (Utils.CIntDef(Ad_Id) > 0 && !string.IsNullOrEmpty(Utils.CStrDef(Ad_Image1)))
                    {
                        _sResult += "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0'  width='960' height='412' id='ShockwaveFlash1' >";
                        _sResult += "<param name='movie' value='" + PathFiles.GetPathAdItems(Utils.CIntDef(Ad_Id)) + Utils.CStrDef(Ad_Image1) + "'>";
                        _sResult += "<param name='Menu' value='0'>";
                        _sResult += "<param name='quality' value='high'>";
                        _sResult += "<param name='wmode' value='transparent'>";
                        _sResult += "<embed width='960' height='412' src='" + PathFiles.GetPathAdItems(Utils.CIntDef(Ad_Id)) + Utils.CStrDef(Ad_Image1) + "' wmode='transparent' ></object>";
                    }

                }
                return _sResult;
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                return "";
            }

        }

        public string GetImageSlideHome(object Ad_Id, object Ad_Image1, object Ad_Target, object Ad_Url, object Ad_Item_Desc)
        {
            try
            {
                string s = "";
                 s+= "<div data-thumb='" + PathFiles.GetPathAdItems(Utils.CIntDef(Ad_Id)) + Utils.CStrDef(Ad_Image1) + "'> ";
                 s+= "<a href='" + Utils.CStrDef(Ad_Url) + "' target='" + Utils.CStrDef(Ad_Target) + "'> ";
                 s+= "<img src='" + PathFiles.GetPathAdItems(Utils.CIntDef(Ad_Id)) + Utils.CStrDef(Ad_Image1) + "' style='width: 790px !important; height: 310px !important;' /> ";
                 s += "<span class='caption elemHover fromLeft'><strong>" + Utils.CStrDef(Ad_Item_Desc) +"</strong><br />";
                 s+= "</span>";
                 s+= "</a> ";
                 s += "</div>";
                 return s;
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                return null;
            }

        }

        public string GetImageCus(object Ad_Id, object Ad_Image1, object Ad_Target, object Ad_Url, object Ad_Item_Desc)
        {
            try
            {
                if (Utils.CIntDef(Ad_Id) > 0 && !string.IsNullOrEmpty(Utils.CStrDef(Ad_Image1)))
                {
                    string str = "";
                            str+="<li class='marquee'>";
                            str += "<a class='bwWrapper' href='" + Utils.CStrDef(Ad_Url) + "' target='" + Utils.CStrDef(Ad_Target) + "' title='" + Utils.CStrDef(Ad_Item_Desc) + "'>";
                            str+="<img src='" + PathFiles.GetPathAdItems(Utils.CIntDef(Ad_Id)) + Utils.CStrDef(Ad_Image1) + "' ";
                            //str += " data-hover='http://www.savicor_vi_1.gif' ";
                            str +=" title='" + Utils.CStrDef(Ad_Item_Desc) + "' alt='" + Utils.CStrDef(Ad_Item_Desc) + "' />"; 
                            str += "</a>";
                            str += "</li>";
                    return str;
                }
                return "";

            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                return null;
            }

        }
        public string GetImageSliderIndex(object Ad_Id, object Ad_Image1, object Ad_Target, object Ad_Url)
        {
            try
            {
                if (Utils.CIntDef(Ad_Id) > 0 && !string.IsNullOrEmpty(Utils.CStrDef(Ad_Image1)))
                    return "<a href='"+ Utils.CStrDef(Ad_Url) +"'> <img src='" + PathFiles.GetPathAdItems(Utils.CIntDef(Ad_Id)) + Utils.CStrDef(Ad_Image1) + "' alt='' /></a>";
                return "";
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                return null;
            }

        }
        //Get images logo - sologan
        public string Getbanner(object Banner_type, object banner_field, object Banner_ID, object Banner_Image)
        {
            string banner = banner_field.ToString();
            return banner == "1" ? "<a href='/trang-chu.html' id='logo' class='fl'>" + GetImage(Banner_type, Banner_ID, Banner_Image) + "</a>" : "<span id='text_logo'>" + GetImagebanner(Banner_type, Banner_ID, Banner_Image) + "</span>";
        }
        public string GetImage(object Banner_type, object Banner_ID, object Banner_Image)
        {
            try
            {
                string _sResult = string.Empty;
                if (Utils.CIntDef(Banner_type) == 0)
                {
                    if (Utils.CIntDef(Banner_ID) > 0 && !string.IsNullOrEmpty(Utils.CStrDef(Banner_Image)))
                        return "<img src='" + PathFiles.GetPathBanner(Utils.CIntDef(Banner_ID)) + Utils.CStrDef(Banner_Image) + "' alt='' />";
                    else
                        return "<img src='/vi-vn/Images/Logo.png'/>";
                }
                else
                {
                    if (Utils.CIntDef(Banner_ID) > 0 && !string.IsNullOrEmpty(Utils.CStrDef(Banner_Image)))
                    {
                        _sResult += "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0'  width='270' height='83' id='ShockwaveFlash1' >";
                        _sResult += "<param name='movie' value='" + PathFiles.GetPathAdItems(Utils.CIntDef(Banner_ID)) + Utils.CStrDef(Banner_Image) + "'>";
                        _sResult += "<param name='Menu' value='0'>";
                        _sResult += "<param name='quality' value='high'>";
                        _sResult += "<param name='wmode' value='transparent'>";
                        _sResult += "<embed width='270' height='83' width='100%' src='" + PathFiles.GetPathBanner(Utils.CIntDef(Banner_ID)) + Utils.CStrDef(Banner_Image) + "' wmode='transparent' ></object>";
                    }

                }
                return _sResult;
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                return null;
            }
        }
        public string GetImagebanner(object Banner_type, object Banner_ID, object Banner_Image)
        {
            try
            {
                string _sResult = string.Empty;
                if (Utils.CIntDef(Banner_type) == 0)
                {
                    if (Utils.CIntDef(Banner_ID) > 0 && !string.IsNullOrEmpty(Utils.CStrDef(Banner_Image)))
                        return "<img src='" + PathFiles.GetPathBanner(Utils.CIntDef(Banner_ID)) + Utils.CStrDef(Banner_Image) + "' alt='' />";
                    else
                        return "<img src='/vi-vn/Images/Logo.png'/>"; ;
                }
                else
                {
                    if (Utils.CIntDef(Banner_ID) > 0 && !string.IsNullOrEmpty(Utils.CStrDef(Banner_Image)))
                    {
                        _sResult += "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0'  width='865' height='60' id='ShockwaveFlash1' >";
                        _sResult += "<param name='movie' value='" + PathFiles.GetPathAdItems(Utils.CIntDef(Banner_ID)) + Utils.CStrDef(Banner_Image) + "'>";
                        _sResult += "<param name='Menu' value='0'>";
                        _sResult += "<param name='quality' value='high'>";
                        _sResult += "<param name='wmode' value='transparent'>";
                        _sResult += "<embed width='865' height='60' width='100%' src='" + PathFiles.GetPathBanner(Utils.CIntDef(Banner_ID)) + Utils.CStrDef(Banner_Image) + "' wmode='transparent' ></object>";
                    }

                }
                return _sResult;
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                return null;
            }
        }
        //Support
        public string Bind_Online(object Type, object Description, object Nickname,object Field1,object Field2)
        {

            try
            {
                //{0}{1}yahoo - nickname
                //{2}{3}skype - Field 1
                //{4}Description
                //{5}Hotline - Field2
                string str = "<a title='Bán hàng trực tuyến' href='ymsgr:sendim?{0}'><img  alt='' src='http://opi.yahoo.com/online?u={1}&m=g&t=2' border='0' /></a>";
                str += "<a title='' href='skype:{2}?call'><img height='16' title='' alt='Chăm sóc khách hàng' src='http://mystatus.skype.com/smallclassic/{3}'></a>";
               
                str += "<br /><span class='title_sp'>{4}</span> <span class='number_phone'>{5}</span>";

                int _iType = Utils.CIntDef(Type);
                string _sResult = string.Empty;
                if (_iType==0)
                {

                    _sResult = String.Format(str, Utils.CStrDef(Nickname), Utils.CStrDef(Nickname), Utils.CStrDef(Field1), Utils.CStrDef(Field1), Utils.CStrDef(Description), Utils.CStrDef(Field2));

                }
                return _sResult;
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                return null;
            }
        }
        public string Bind_Online(object Type, object Description, object Nickname)
        {

            try
            {
                int _iType = Utils.CIntDef(Type);
                string _sResult = string.Empty;
                switch (_iType)
                {
                    case 0:
                        _sResult += "<a href='ymsgr:sendim?" + Utils.CStrDef(Nickname) + "' title='" + Utils.CStrDef(Description) + "'>";
                        _sResult += "<img src='http://opi.yahoo.com/online?u=" + Utils.CStrDef(Nickname) + "&m=g&t=1'   border='0' height='16' />";
                        _sResult += "</a>";

                        break;
                    case 1:
                        _sResult += "<a href='skype:" + Utils.CStrDef(Nickname) + "?call' title='" + Utils.CStrDef(Description) + "'>";
                        _sResult += "<img src='http://mystatus.skype.com/smallclassic/" + Utils.CStrDef(Nickname) + "' title=" + Utils.CStrDef(Description) + "  alt='' height='16' >";
                        _sResult += "</a>";
                        break;
                    //case 2:
                    //    _sResult += "<li><span class='number_phone'>" + Utils.CStrDef(Description) + "</span></li>";
                    //    break;
                    default:
                        break;
                }
                return _sResult;
            }
            catch (Exception ex)
            {
                clsVproErrorHandler.HandlerError(ex);
                return null;
            }
        }
    }
}
