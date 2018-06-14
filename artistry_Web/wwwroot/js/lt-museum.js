    jQuery(document).ready(function () {
        jQuery(document.body).SLScrollToTop({
            'image': '',
            'text': '',
            'title': 'Go To Top',
            'className': 'scrollToTop',
            'duration': 500
        });
    });
        if (typeof (WebFont) !== 'undefined') {
        WebFont.load({
            google: {
                families: ['Vollkorn', 'Montserrat']
            }
        });
    }
    var lt_stable_template = "ltmuseum";
    var lt_stable_template_uri = "http://demo5.ltheme.com/joomla/lt-museum/templates/ltmuseum";

        jQuery(function ($) {$('.helix3-toggler').on('click', function (event) { event.preventDefault(); $(this).parent().parent().toggleClass('opened'); }); var presets = $('.helix3-presets').find('li'); presets.each(function () {$(this).find('a').on('click', function (event) { event.preventDefault(); var currentPreset = $(this).parent().data('preset'); presets.removeClass('active'); $(this).parent().addClass('active'); $('.sp-default-logo').removeAttr('src').attr('src', lt_stable_template_uri + '/images/presets/preset' + currentPreset + '/logo.png'); $('.sp-retina-logo').removeAttr('src').attr('src', lt_stable_template_uri + '/images/presets/preset' + currentPreset + '/logo@2x.png'); $('.preset').removeAttr('href').attr('href', lt_stable_template_uri + '/css/presets/preset' + currentPreset + '.css'); $.removeCookie(lt_stable_template + '_preset'); $.cookie(lt_stable_template + '_preset', 'preset' + currentPreset, { expires: 1 }); }); }); $('#helix3-boxed').on('change', function () { if ($(this).is(':checked')) {$('body').addClass('layout-boxed'); } else {$('body').removeClass('layout-boxed'); } }); $('.helix3-bg-images li').on('click', function (event) {event.preventDefault(); var $this = $(this); if ($('#helix3-boxed').is(':checked')) {$('body').removeAttr('style').css({ 'background': 'url(' + $this.data('bg') + ') no-repeat 50% 50%', 'background-attachment': 'fixed', 'background-size': 'cover' }); $('.helix3-bg-images li').removeClass('active'); $this.addClass('active'); } else {alert('This option required Select Boxed Layout'); } }); $('#helix3-boxed').on('change', function () { if ($(this).is(':checked')) {$('body').addClass('layout-boxed'); } else {$('body').removeClass('layout-boxed').removeAttr('style'); $('.helix3-bg-images li').removeClass('active'); } }); });

        jQuery(document).ready(function ($) {
            if (window != window.top) {
        $(".free-template-download").hide();
    }
});
var sp_preloader = '';

var sp_gotop = '';

var sp_offanimation = 'default';

        if (typeof acymailingModule == 'undefined') {
            var acymailingModule = Array();
}

        acymailingModule['emailRegex'] = /^[a-z0-9!#$%&\'*+\/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&\'*+\/=?^_`{|}~-]+)*\@@([a-z0-9-]+\.)+[a-z0-9]{2,10}$/i;

    acymailingModule['NAMECAPTION'] = 'Name';
    acymailingModule['NAME_MISSING'] = 'Please enter your name';
    acymailingModule['EMAILCAPTION'] = 'E-mail';
    acymailingModule['VALID_EMAIL'] = 'Please enter a valid e-mail address';
    acymailingModule['ACCEPT_TERMS'] = 'Please check the Terms and Conditions';
    acymailingModule['CAPTCHA_MISSING'] = 'The captcha is invalid, please try again';
    acymailingModule['NO_LIST_SELECTED'] = 'Please select the lists you want to subscribe to';

    new WOW().init();

        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
            (i[r].q = i[r].q || []).push(arguments)
        }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
    })(window, document, 'script', 'https://www.google-analytics.com/analytics.js', 'ga');
    ga('create', 'UA-45098864-1', 'auto');
    ga('send', 'pageview');

/*<![CDATA[*/window.olark || (function (c) {
                var f = window, d = document, l = f.location.protocol == "https:" ? "https:" : "http:", z = c.name, r = "load"; var nt = function () {
                f[z] = function () {
                    (a.s = a.s || []).push(arguments)
                }; var a = f[z]._ = {
            }, q = c.methods.length; while (q--) {
                (function (n) {
                    f[z][n] = function () {
                        f[z]("call", n, arguments)
                    }
                })(c.methods[q])
            } a.l = c.loader; a.i = nt; a.p = {
                0: +new Date
                    }; a.P = function (u) {
                a.p[u] = new Date - a.p[0]
            }; function s() {
                a.P(r); f[z](r)
                    } f.addEventListener ? f.addEventListener(r, s, false) : f.attachEvent("on" + r, s); var ld = function () {
                function p(hd) {
                    hd = "head"; return ["<", hd, "></", hd, "><", i, ' onl' + 'oad="var d=', g, ";d.getElementsByTagName('head')[0].", j, "(d.", h, "('script')).", k, "='", l, "//", a.l, "'", '"', "></", i, ">"].join("")
                } var i = "body", m = d[i]; if (!m) {
                            return setTimeout(ld, 100)
                        } a.P(1); var j = "appendChild", h = "createElement", k = "src", n = d[h]("div"), v = n[j](d[h](z)), b = d[h]("iframe"), g = "document", e = "domain", o; n.style.display = "none"; m.insertBefore(n, m.firstChild).id = z; b.frameBorder = "0"; b.id = z + "-loader"; if (/MSIE[ ]+6/.test(navigator.userAgent)) {
                b.src = "javascript:false"
            } b.allowTransparency = "true"; v[j](b); try {
                b.contentWindow[g].open()
            } catch (w) {
                c[e] = d[e]; o = "javascript:var d=" + g + ".open();d.domain='" + d.domain + "';"; b[k] = o + "void(0);"
                        } try {
                            var t = b.contentWindow[g]; t.write(p()); t.close()
                        } catch (x) {
                b[k] = o + 'd.write("' + p().replace(/"/g, String.fromCharCode(92) + '"') + '");d.close();'
            } a.P(2)
        }; ld()
    }; nt()
            })({
                loader: "static.olark.com/jsclient/loader0.js", name: "olark", methods: ["configure", "extend", "declare", "identify"]
        });
        /* custom configuration goes here (www.olark.com/documentation) */
            olark.identify('8572-355-10-5083');/*]]>*/
        <noscript><a href="https://www.olark.com/site/8572-355-10-5083/contact" title="Contact us" target="_blank">Questions? Feedback?</a> powered by <a href="http://www.olark.com?welcome" title="Olark live chat software">Olark live chat software</a></noscript>
