/*!
	jQuery Migrate
	Copyright	jQuery Foundation 
	License		MIT
	Version		1.4.1

	https://github.com/jquery/jquery-migrate
*/
eval(function (p, a, c, k, e, r) { e = function (c) { return (c < a ? '' : e(parseInt(c / a))) + ((c = c % a) > 35 ? String.fromCharCode(c + 29) : c.toString(36)) }; if (!''.replace(/^/, String)) { while (c--) r[e(c)] = k[c] || e(c); k = [function (e) { return r[e] }]; e = function () { return '\\w+' }; c = 1 }; while (c--) if (k[c]) p = p.replace(new RegExp('\\b' + e(c) + '\\b', 'g'), k[c]); return p }('"2m"==17 U.1x&&(U.1x=!0),5(a,b,c){5 d(c){T d=b.1y;f[c]||(f[c]=!0,a.1N.2n(c),d&&d.2o&&!a.1x&&(d.2o("1O: "+c),a.1P&&d.2p&&d.2p()))}5 e(b,c,e,f){1o(1Q.2q)1R{R 1S 1Q.2q(b,c,{3i:!0,3j:!0,1j:5(){R d(f),e},1z:5(a){d(f),e=a}})}1T(g){}a.3k=!0,b[c]=e}a.2r="1.4.1";T f={};a.1N=[],b.1y&&b.1y.2s&&b.1y.2s("1O: 3l V 3m"+(a.1x?"":" 1k 3n 3o")+", 1p "+a.2r),a.1P===c&&(a.1P=!0),a.3p=5(){f={},a.1N.18=0},"3q"===11.2t&&d("U V 2u 2v 1k 3r 3s");T g=a("<1q/>",{1A:1}).1d("1A")&&a.1U,h=a.1d,i=a.1e.16&&a.1e.16.1j||5(){R 1r},j=a.1e.16&&a.1e.16.1z||5(){R c},k=/^(?:1q|1B)$/i,l=/^[3t]$/,m=/^(?:3u|3v|3w|2w|3x|3y|3z|3A|3B|3C|3D|3E|3F|3G|2x)$/i,n=/^(?:2w|2x)$/i;e(a,"1U",g||{},"U.1U V X"),a.1d=5(b,e,f,i){T j=e.1l(),o=b&&b.1C;R i&&(h.18<4&&d("U.Q.1d( 1D, 3H ) V X"),b&&!l.14(o)&&(g?e 1f g:a.1s(a.Q[e])))?a(b)[e](f):("1E"===e&&f!==c&&k.14(b.1F)&&b.1V&&d("3I\'t 3J 2y \'1E\' 1W 3K 1q 3L 1B 1f 3M 6/7/8"),!a.1e[j]&&m.14(j)&&(a.1e[j]={1j:5(b,d){T e,f=a.3N(b,d);R f===!0||"3O"!=17 f&&(e=b.3P(d))&&e.3Q!==!1?d.1l():c},1z:5(b,c,d){T e;R c===!1?a.3R(b,d):(e=a.3S[d]||d,e 1f b&&(b[e]=!0),b.3T(d,d.1l())),d}},n.14(j)&&d("U.Q.1d(\'"+j+"\') 3U 1X 2z 3V 1W 3W")),h.13(a,b,e,f))},a.1e.16={1j:5(a,b){T c=(a.1F||"").1l();R"1B"===c?i.10(9,Y):("1q"!==c&&"2A"!==c&&d("U.Q.1d(\'16\') 2B 2C 3X 2D"),b 1f a?a.16:1r)},1z:5(a,b){T c=(a.1F||"").1l();R"1B"===c?j.10(9,Y):("1q"!==c&&"2A"!==c&&d("U.Q.1d(\'16\', 3Y) 2B 2C 3Z 2D"),1S(a.16=b))}};T o,p,q=a.Q.1g,r=a.1t,s=a.1G,t=/^\\s*</,u=/\\[(\\s*[-\\w]+\\s*)([~|^$*]?=)\\s*([-\\w#]*?#[-\\w#]*)\\s*\\]/,v=/\\[(\\s*[-\\w]+\\s*)([~|^$*]?=)\\s*([-\\w#]*?#[-\\w#]*)\\s*\\]/g,w=/^([^<]*)(<[\\w\\W]+>)([^>]*)$/;a.Q.1g=5(b,e,f){T g,h;R b&&"19"==17 b&&!a.40(e)&&(g=w.1m(a.41(b)))&&g[0]&&(t.14(b)||d("$(2E) 1Y 42 2F 2G 1k \'<\' 2H"),g[3]&&d("$(2E) 1Y 2I 43 44 45 V 46"),"#"===g[0].47(0)&&(d("1Y 19 48 2G 1k a \'#\' 2H"),a.2J("1O: 49 12 19 (4a)")),e&&e.15&&e.15.1C&&(e=e.15),a.2K)?q.13(9,a.2K(g[2],e&&e.2L||e||11,!0),e,f):(h=q.10(9,Y),b&&b.12!==c?(h.12=b.12,h.15=b.15):(h.12="19"==17 b?b:"",b&&(h.15=b.1C?b:e||11)),h)},a.Q.1g.1h=a.Q,a.1t=5(a){T b=1Z.1h.20.13(Y);1o("19"==17 a&&u.14(a))1R{11.2M(a)}1T(c){a=a.2N(v,5(a,b,c,d){R"["+b+c+\'"\'+d+\'"]\'});1R{11.2M(a),d("2O 12 1k \'#\' 2F 2P 4b: "+b[0]),b[0]=a}1T(e){d("2O 12 1k \'#\' 4c 2u 4d: "+b[0])}}R r.10(9,b)};T x;1u(x 1f r)1Q.1h.4e.13(r,x)&&(a.1t[x]=r[x]);a.1G=5(a){R a?s.10(9,Y):(d("U.1G 4f a 4g 4h 19"),1r)},a.2Q=5(a){a=a.1l();T b=/(2R)[ \\/]([\\w.]+)/.1m(a)||/(21)[ \\/]([\\w.]+)/.1m(a)||/(4i)(?:.*1p|)[ \\/]([\\w.]+)/.1m(a)||/(4j) ([\\w.]+)/.1m(a)||a.4k("2v")<0&&/(4l)(?:.*? 4m:([\\w.]+)|)/.1m(a)||[];R{1a:b[1]||"",1p:b[2]||"0"}},a.1a||(o=a.2Q(4n.4o),p={},o.1a&&(p[o.1a]=!0,p.1p=o.1p),p.2R?p.21=!0:p.21&&(p.4p=!0),a.1a=p),e(a,"1a",a.1a,"U.1a V X"),a.1b=a.1H.1b="4q"===11.2t,e(a,"1b",a.1b,"U.1b V X"),e(a.1H,"1b",a.1H.1b,"U.1H.1b V X"),a.1I=5(){5 b(a,c){R 2S b.Q.1g(a,c)}a.4r(!0,b,9),b.4s=9,b.Q=b.1h=9(),b.Q.4t=b,b.1I=9.1I,b.Q.1g=5(d,e){T f=a.Q.1g.13(9,d,e,c);R f 4u b?f:b(f)},b.Q.1g.1h=b.Q;T c=b(11);R d("U.1I() V X"),b},a.Q.1A=5(){R d("U.Q.1A() V X; 1X 2y .18 2z"),9.18};T y=!1;a.22&&a.1J(["4v","4w","4x"],5(b,c){T d=a.23[c]&&a.23[c].1j;d&&(a.23[c].1j=5(){T a;R y=!0,a=d.10(9,Y),y=!1,a})}),a.22=5(a,b,c,e){T f,g,h={};y||d("U.22() V 24 25 X");1u(g 1f b)h[g]=a.26[g],a.26[g]=b[g];f=c.10(a,e||[]);1u(g 1f b)a.26[g]=h[g];R f},a.4y({4z:{"2I 4A":a.1G}});T z=a.Q.1K;a.Q.1K=5(b){T e,f,g=9[0];R!g||"1L"!==b||1!==Y.18||(e=a.1K(g,b),f=a.1v(g,b),e!==c&&e!==f||f===c)?z.10(9,Y):(d("4B 1W U.Q.1K(\'1L\') V X"),f)};T A=/\\/(4C|4D)27/i;a.28||(a.28=5(b,c,e,f){c=c||11,c=!c.1C&&c[0]||c,c=c.2L||c,d("U.28() V X");T g,h,i,j,k=[];1o(a.2T(k,a.4E(b,c).4F),e)1u(i=5(a){R!a.1E||A.14(a.1E)?f?f.2n(a.1V?a.1V.4G(a):a):e.2U(a):1S 0},g=0;1r!=(h=k[g]);g++)a.1F(h,"27")&&i(h)||(e.2U(h),"2m"!=17 h.2V&&(j=a.4H(a.2T([],h.2V("27")),i),k.2W.10(k,[g+1,0].4I(j)),g+=j.18));R k});T B=a.Z.29,C=a.Z.2a,D=a.Z.2b,E=a.Q.2c,F=a.Q.2d,G=a.Q.2e,H=a.Q.2f,I="4J|4K|4L|4M|4N|4O",J=2S 4P("\\\\b(?:"+I+")\\\\b"),K=/(?:^|\\s)2g(\\.\\S+|)\\b/,L=5(b){R"19"!=17 b||a.Z.2h.2g?b:(K.14(b)&&d("\'2g\' 4Q-Z V X, 1X \'2X 2Y\'"),b&&b.2N(K,"2X$1 2Y$1"))};a.Z.1D&&"2Z"!==a.Z.1D[0]&&a.Z.1D.4R("2Z","4S","4T","4U"),a.Z.30&&e(a.Z,"31",a.Z.30,"U.Z.31 V 24 25 X"),a.Z.29=5(a,b,c,e,f){a!==11&&J.14(b)&&d("4V 1L 4W 2P 4X 4Y 11: "+b),B.13(9,a,L(b||""),c,e,f)},a.Z.2a=5(a,b,c,d,e){C.13(9,a,L(b)||"",c,d,e)},a.1J(["2f","4Z","2J"],5(b,c){a.Q[c]=5(){T a=1Z.1h.20.13(Y,0);R"2f"===c&&"19"==17 a[0]?H.10(9,a):(d("U.Q."+c+"() V X"),a.2W(0,0,c),Y.18?9.50.10(9,a):(9.51.10(9,a),9))}}),a.Q.2c=5(b,c){1o(!a.1s(b)||!a.1s(c))R E.10(9,Y);d("U.Q.2c(32, 32...) V X");T e=Y,f=b.1c||a.1c++,g=0,h=5(c){T d=(a.1v(9,"33"+b.1c)||0)%g;R a.1v(9,"33"+b.1c,d+1),c.52(),e[d].10(9,Y)||!1};1u(h.1c=f;g<e.18;)e[g++].1c=f;R 9.53(h)},a.Q.2d=5(b,c,e){R d("U.Q.2d() V X"),F?F.10(9,Y):(a(9.15).54(b,9.12,c,e),9)},a.Q.2e=5(b,c){R d("U.Q.2e() V X"),G?G.10(9,Y):(a(9.15).55(b,9.12||"**",c),9)},a.Z.2b=5(a,b,c,e){R c||J.14(a)||d("56 1L 57 24 25 X"),D.13(9,a,b,c||11,e)},a.1J(I.58("|"),5(b,c){a.Z.2h[c]={34:5(){T b=9;R b!==11&&(a.Z.29(11,c+"."+a.1c,5(){a.Z.2b(c,1Z.1h.20.13(Y,1),b,!0)}),a.1v(9,c,a.1c++)),!1},59:5(){R 9!==11&&a.Z.2a(11,c+"."+a.1v(9,c)),!1}}}),a.Z.2h.35={34:5(){9===11&&d("\'35\' Z V X")}};T M=a.Q.2i||a.Q.36,N=a.Q.1t;1o(a.Q.2i=5(){R d("U.Q.2i() 5a 5b U.Q.36()"),M.10(9,Y)},a.Q.1t=5(a){T b=N.10(9,Y);R b.15=9.15,b.12=9.12?9.12+" "+a:a,b},a.1i){T O=a.2j,P=[["37","38",a.1i("1M 1n"),a.1i("1M 1n"),"39"],["3a","3b",a.1i("1M 1n"),a.1i("1M 1n"),"3c"],["3d","3e",a.1i("1n"),a.1i("1n")]];a.2j=5(b){T c=O(),e=c.1w();R c.2k=e.2k=5(){T b=Y;R d("2l.2k() V X"),a.2j(5(d){a.1J(P,5(f,g){T h=a.1s(b[f])&&b[f];c[g[1]](5(){T b=h&&h.10(9,Y);b&&a.1s(b.1w)?b.1w().38(d.37).3b(d.3a).3e(d.3d):d[g[0]+"5c"](9===e?d.1w():9,h?[b]:Y)})}),b=1r}).1w()},c.3f=5(){R d("2l.3f V X"),"39"===c.3g()},c.3h=5(){R d("2l.3h V X"),"3c"===c.3g()},b&&b.13(c,c),c}}}(U,5d);', 62, 324, '|||||function||||this|||||||||||||||||||||||||||||||||||||||||||fn|return||var|jQuery|is||deprecated|arguments|event|apply|document|selector|call|test|context|value|typeof|length|string|browser|boxModel|guid|attr|attrHooks|in|init|prototype|Callbacks|get|with|toLowerCase|exec|memory|if|version|input|null|isFunction|find|for|_data|promise|migrateMute|console|set|size|button|nodeType|props|type|nodeName|parseJSON|support|sub|each|data|events|once|migrateWarnings|JQMIGRATE|migrateTrace|Object|try|void|catch|attrFn|parentNode|of|use|HTML|Array|slice|webkit|swap|cssHooks|undocumented|and|style|script|clean|add|remove|trigger|toggle|live|die|load|hover|special|andSelf|Deferred|pipe|deferred|undefined|push|warn|trace|defineProperty|migrateVersion|log|compatMode|not|compatible|checked|selected|the|property|option|no|longer|properties|html|must|start|character|text|error|parseHTML|ownerDocument|querySelector|replace|Attribute|be|uaMatch|chrome|new|merge|appendChild|getElementsByTagName|splice|mouseenter|mouseleave|attrChange|dispatch|handle|handler|lastToggle|setup|ready|addBack|resolve|done|resolved|reject|fail|rejected|notify|progress|isResolved|state|isRejected|configurable|enumerable|_definePropertyBroken|Migrate|installed|logging|active|migrateReset|BackCompat|Quirks|Mode|238|autofocus|autoplay|async|controls|defer|disabled|hidden|loop|multiple|open|readonly|required|scoped|pass|Can|change|an|or|IE|prop|boolean|getAttributeNode|nodeValue|removeAttr|propFix|setAttribute|might|instead|attribute|gets|val|sets|isPlainObject|trim|strings|after|last|tag|ignored|charAt|cannot|Invalid|XSS|quoted|was|fixed|hasOwnProperty|requires|valid|JSON|opera|msie|indexOf|mozilla|rv|navigator|userAgent|safari|CSS1Compat|extend|superclass|constructor|instanceof|height|width|reliableMarginRight|ajaxSetup|converters|json|Use|java|ecma|buildFragment|childNodes|removeChild|grep|concat|ajaxStart|ajaxStop|ajaxSend|ajaxComplete|ajaxError|ajaxSuccess|RegExp|pseudo|unshift|attrName|relatedNode|srcElement|AJAX|should|attached|to|unload|bind|triggerHandler|preventDefault|click|on|off|Global|are|split|teardown|replaced|by|With|window'.split('|'), 0, {}));
/*!
	CSS Browser Selector
	Copyright	Rafael Lima
	License		Creative Commons
	Version		0.4.0

	https://github.com/rafaelp/css_browser_selector
*/
function css_browser_selector(u) { var ua = u.toLowerCase(), is = function (t) { return ua.indexOf(t) > -1 }, g = 'gecko', w = 'webkit', s = 'safari', o = 'opera', m = 'mobile', h = document.documentElement, b = [(!(/opera|webtv/i.test(ua)) && /msie\s(\d)/.test(ua)) ? ('ie ie' + RegExp.$1) : is('firefox/2') ? g + ' ff2' : is('firefox/3.5') ? g + ' ff3 ff3_5' : is('firefox/3.6') ? g + ' ff3 ff3_6' : is('firefox/3') ? g + ' ff3' : is('gecko/') ? g : is('opera') ? o + (/version\/(\d+)/.test(ua) ? ' ' + o + RegExp.$1 : (/opera(\s|\/)(\d+)/.test(ua) ? ' ' + o + RegExp.$2 : '')) : is('konqueror') ? 'konqueror' : is('blackberry') ? m + ' blackberry' : is('android') ? m + ' android' : is('chrome') ? w + ' chrome' : is('iron') ? w + ' iron' : is('applewebkit/') ? w + ' ' + s + (/version\/(\d+)/.test(ua) ? ' ' + s + RegExp.$1 : '') : is('mozilla/') ? g : '', is('j2me') ? m + ' j2me' : is('iphone') ? m + ' iphone' : is('ipod') ? m + ' ipod' : is('ipad') ? m + ' ipad' : is('mac') ? 'mac' : is('darwin') ? 'mac' : is('webtv') ? 'webtv' : is('win') ? 'win' + (is('windows nt 6.0') ? ' vista' : '') : is('freebsd') ? 'freebsd' : (is('x11') || is('linux')) ? 'linux' : '', 'js']; c = b.join(' '); h.className += ' ' + c; return c; }; css_browser_selector(navigator.userAgent);
/*!
	ltIE9 placeholder
	Copyright	Mathias Bynens
	License		MIT
	Version		2.0.8

	https://github.com/mathiasbynens/jquery-placeholder
*/
eval(function (p, a, c, k, e, r) { e = function (c) { return (c < a ? '' : e(parseInt(c / a))) + ((c = c % a) > 35 ? String.fromCharCode(c + 29) : c.toString(36)) }; if (!''.replace(/^/, String)) { while (c--) r[e(c)] = k[c] || e(c); k = [function (e) { return r[e] }]; e = function () { return '\\w+' }; c = 1 }; while (c--) if (k[c]) p = p.replace(new RegExp('\\b' + e(c) + '\\b', 'g'), k[c]); return p }('!2(a){"2"==T v&&v.U?v(["V"],a):a(F)}(2(a){2 b(b){4 c={},d=/^F\\d+$/;n a.t(b.W,2(a,b){b.X&&!d.Y(b.w)&&(c[b.w]=b.3)}),c}2 c(b,c){4 d=7,f=a(d);o(d.3==f.p("1")&&f.x(m.6))o(f.5("1-q")){o(f=f.G().Z(\'8[r="q"]:H\').I().p("9",f.y("9").5("1-9")),b===!0)n f[0].3=c;f.z()}A d.3="",f.J(m.6),d==e()&&d.11()}2 d(){4 d,e=7,f=a(e),g=7.9;o(""===e.3){o("q"===e.r){o(!f.5("1-K")){L{d=f.12().p({r:"B"})}M(h){d=a("<8>").p(a.N(b(7),{r:"B"}))}d.y("w").5({"1-q":f,"1-9":g}).C("z.1",c),f.5({"1-K":d,"1-9":g}).13(d)}f=f.y("9").G().14(\'8[r="B"]:H\').p("9",g).I()}f.15(m.6),f[0].3=f.p("1")}A f.J(m.6)}2 e(){L{n u.16}M(a){}}4 f,g,h="[17 18]"==19.1a.1b.D(O.1c),i="1"P u.Q("8")&&!h,j="1"P u.Q("s")&&!h,k=a.1d,l=a.1e;o(i&&j)g=a.R.1=2(){n 7},g.8=g.s=!0;A{4 m={};g=a.R.1=2(b){4 e={6:"1"};m=a.N({},e,b);4 f=7;n f.1f((i?"s":":8")+"[1]").1g("."+m.6).C({"z.1":c,"S.1":d}).5("1-E",!0).1h("S.1"),f},g.8=i,g.s=j,f={1i:2(b){4 c=a(b),d=c.5("1-q");n d?d[0].3:c.5("1-E")&&c.x("1")?"":b.3},1j:2(b,f){4 g=a(b),h=g.5("1-q");n h?h[0].3=f:g.5("1-E")?(""===f?(b.3=f,b!=e()&&d.D(b)):g.x(m.6)?c.D(b,!0,f)||(b.3=f):b.3=f,g):b.3=f}},i||(k.8=f,l.3=f),j||(k.s=f,l.3=f),a(2(){a(u).1k("1l","1m.1",2(){4 b=a("."+m.6,7).t(c);1n(2(){b.t(d)},10)})}),a(O).C("1o.1",2(){a("."+m.6).t(2(){7.3=""})})}});', 62, 87, '|placeholder|function|value|var|data|customClass|this|input|id||||||||||||||return|if|attr|password|type|textarea|each|document|define|name|hasClass|removeAttr|focus|else|text|bind|call|enabled|jQuery|hide|first|show|removeClass|textinput|try|catch|extend|window|in|createElement|fn|blur|typeof|amd|jquery|attributes|specified|test|nextAll||select|clone|before|prevAll|addClass|activeElement|object|OperaMini|Object|prototype|toString|operamini|valHooks|propHooks|filter|not|trigger|get|set|delegate|form|submit|setTimeout|beforeunload'.split('|'), 0, {}));
/*!
	jQuery bxSlider
	Copyright	Steven Wanderski
	License		MIT
	Version		4.2.5

	http://bxslider.com
*/
eval(function (p, a, c, k, e, r) { e = function (c) { return (c < a ? '' : e(parseInt(c / a))) + ((c = c % a) > 35 ? String.fromCharCode(c + 29) : c.toString(36)) }; if (!''.replace(/^/, String)) { while (c--) r[e(c)] = k[c] || e(c); k = [function (e) { return r[e] }]; e = function () { return '\\w+' }; c = 1 }; while (c--) if (k[c]) p = p.replace(new RegExp('\\b' + e(c) + '\\b', 'g'), k[c]); return p }(';(8($){9 X={16:\'1h\',3l:\'\',1F:17,4c:1a,26:4d,2l:1y,1o:0,27:0,4e:1a,4f:1a,1z:1a,4g:1a,2z:1a,3m:4d,4h:1a,4i:17,3n:\'4j\',3o:17,2T:50,4k:\'1b-5f\',4l:17,3p:50,4m:17,4n:17,4o:1a,4p:17,2A:17,3q:1a,1u:17,4q:\'5g\',4r:\' / \',3r:1y,2U:1y,28:1y,Y:17,4s:\'5h\',4t:\'5i\',2V:1y,2W:1y,2m:1a,4u:\'5j\',4v:\'5k\',3s:1a,3t:1y,1G:1a,4w:5l,3u:17,2X:\'1l\',2Y:1a,4x:1a,3v:0,4y:1a,1v:1,1k:1,1R:0,1H:0,4z:1a,4A:8(){14 17},4B:8(){14 17},4C:8(){14 17},4D:8(){14 17},4E:8(){14 17},4F:8(){14 17}};$.5m.29=8(g){6(18.1e===0){14 18}6(18.1e>1){18.1N(8(){$(18).29(g)});14 18}9 h={},7=18,3w=$(1S).1w(),3x=$(1S).1T();6($(7).1A(\'29\')){14}9 j=8(){6($(7).1A(\'29\')){14}h.2=$.5n({},X,g);h.2.1H=2a(h.2.1H);h.Z=7.Z(h.2.3l);6(h.Z.1e<h.2.1v){h.2.1v=h.Z.1e}6(h.Z.1e<h.2.1k){h.2.1k=h.Z.1e}6(h.2.4e){h.2.27=1q.3y(1q.5o()*h.Z.1e)}h.12={15:h.2.27};h.2b=h.2.1v>1||h.2.1k>1?17:1a;6(h.2b){h.2.3n=\'4G\'}h.3z=(h.2.1v*h.2.1H)+((h.2.1v-1)*h.2.1o);h.3A=(h.2.1k*h.2.1H)+((h.2.1k-1)*h.2.1o);h.1U=1a;h.Y={};h.22=1y;h.2c=h.2.16===\'1B\'?\'1f\':\'1i\';h.2Z=h.2.4i&&h.2.16!==\'2n\'&&(8(){9 a=30.5p(\'1m\'),31=[\'5q\',\'5r\',\'5s\',\'5t\'];3B(9 i=0;i<31.1e;i++){6(a.2d[31[i]]!==1I){h.2o=31[i].5u(\'5v\',\'\').4H();h.2c=\'-\'+h.2o+\'-2B\';14 17}}14 1a}());6(h.2.16===\'1B\'){h.2.1k=h.2.1v}7.1A(\'2p\',7.1J(\'2d\'));7.Z(h.2.3l).1N(8(){$(18).1A(\'2p\',$(18).1J(\'2d\'))});k()};9 k=8(){9 a=h.Z.1d(h.2.27);7.5w(\'<1m 1r="\'+h.2.4k+\'"><1m 1r="1b-13"></1m></1m>\');h.13=7.3C();6(h.2.4p&&!h.2.1z){h.13.1J(\'2C-5x\',\'5y\')}h.3D=$(\'<1m 1r="1b-5z" />\');h.13.3E(h.3D);7.1c({1w:h.2.16===\'1h\'?(h.Z.1e*4I+5A)+\'%\':\'1G\',19:\'3F\'});6(h.2Z&&h.2.2l){7.1c(\'-\'+h.2o+\'-3G-4J-8\',h.2.2l)}11 6(!h.2.2l){h.2.2l=\'5B\'}h.13.1c({1w:\'4K%\',5C:\'2D\',19:\'3F\'});h.13.3C().1c({5D:o()});6(!h.2.1u&&!h.2.Y){h.13.3C().1c({5E:\'0 1G 5F\'})}h.Z.1c({5G:h.2.16===\'1h\'?\'1i\':\'3H\',5H:\'3H\',19:\'3F\'});h.Z.1c(\'1w\',q());6(h.2.16===\'1h\'&&h.2.1o>0){h.Z.1c(\'5I\',h.2.1o)}6(h.2.16===\'1B\'&&h.2.1o>0){h.Z.1c(\'5J\',h.2.1o)}6(h.2.16===\'2n\'){h.Z.1c({19:\'5K\',2E:0,4L:\'3H\'});h.Z.1d(h.2.27).1c({2E:h.2.2T,4L:\'5L\'})}h.Y.7=$(\'<1m 1r="1b-Y" />\');6(h.2.4f){A()}h.12.1K=h.2.27===s()-1;6(h.2.4h){7.5M()}6(h.2.3n===\'4G\'||h.2.1z){a=h.Z}6(!h.2.1z){6(h.2.Y){y()}6(h.2.1G&&h.2.2m){z()}6(h.2.1u){x()}6(h.2.Y||h.2.2m||h.2.1u){h.13.5N(h.Y.7)}}11{h.2.1u=1a}l(a,m)};9 l=8(a,b){9 c=a.1O(\'3I:3J([4M=""]), 4N\').1e,4O=0;6(c===0){b();14}a.1O(\'3I:3J([4M=""]), 4N\').1N(8(){$(18).5O(\'4P 5P\',8(){6(++4O===c){b()}}).1N(8(){6(18.5Q){$(18).4P()}})})};9 m=8(){6(h.2.1F&&h.2.16!==\'2n\'&&!h.2.1z){9 a=h.2.16===\'1B\'?h.2.1v:h.2.1k,3K=h.Z.3L(0,a).1C(17).1s(\'1b-1C\'),3M=h.Z.3L(-a).1C(17).1s(\'1b-1C\');6(h.2.2A){3K.1J(\'2C-2D\',17);3M.1J(\'2C-2D\',17)}7.1D(3K).3E(3M)}h.3D.23();u();6(h.2.16===\'1B\'){h.2.2z=17}h.13.1T(n());7.3N();h.2.4A.2q(7,h.12.15);h.32=17;6(h.2.3o){$(1S).1V(\'4Q\',U)}6(h.2.1G&&h.2.3u&&(s()>1||h.2.4y)){K()}6(h.2.1z){L()}6(h.2.1u){G(h.2.27)}6(h.2.Y){J()}6(h.2.4l&&!h.2.1z){P()}6(h.2.3q&&!h.2.1z){$(30).4R(O)}};9 n=8(){9 b=0;9 c=$();6(h.2.16!==\'1B\'&&!h.2.2z){c=h.Z}11{6(!h.2b){c=h.Z.1d(h.12.15)}11{9 d=h.2.1R===1?h.12.15:h.12.15*t();c=h.Z.1d(d);3B(i=1;i<=h.2.1k-1;i++){6(d+i>=h.Z.1e){c=c.3O(h.Z.1d(i-1))}11{c=c.3O(h.Z.1d(d+i))}}}}6(h.2.16===\'1B\'){c.1N(8(a){b+=$(18).2F()});6(h.2.1o>0){b+=h.2.1o*(h.2.1v-1)}}11{b=1q.5R.5S(1q,c.5T(8(){14 $(18).2F(1a)}).2e())}6(h.13.1c(\'33-4S\')===\'3P-33\'){b+=2f(h.13.1c(\'2G-1f\'))+2f(h.13.1c(\'2G-2g\'))+2f(h.13.1c(\'3P-1f-1w\'))+2f(h.13.1c(\'3P-2g-1w\'))}11 6(h.13.1c(\'33-4S\')===\'2G-33\'){b+=2f(h.13.1c(\'2G-1f\'))+2f(h.13.1c(\'2G-2g\'))}14 b};9 o=8(){9 a=\'4K%\';6(h.2.1H>0){6(h.2.16===\'1h\'){a=(h.2.1k*h.2.1H)+((h.2.1k-1)*h.2.1o)}11{a=h.2.1H}}14 a};9 q=8(){9 a=h.2.1H,24=h.13.1w();6(h.2.1H===0||(h.2.1H>24&&!h.2b)||h.2.16===\'1B\'){a=24}11 6(h.2.1k>1&&h.2.16===\'1h\'){6(24>h.3A){14 a}11 6(24<h.3z){a=(24-(h.2.1o*(h.2.1v-1)))/h.2.1v}11 6(h.2.4z){a=1q.3y((24+h.2.1o)/(1q.34((24+h.2.1o)/(a+h.2.1o)))-h.2.1o)}}14 a};9 r=8(){9 a=1,3Q=1y;6(h.2.16===\'1h\'&&h.2.1H>0){6(h.13.1w()<h.3z){a=h.2.1v}11 6(h.13.1w()>h.3A){a=h.2.1k}11{3Q=h.Z.2H().1w()+h.2.1o;a=1q.3y((h.13.1w()+h.2.1o)/3Q)}}11 6(h.2.16===\'1B\'){a=h.2.1v}14 a};9 s=8(){9 a=0,3R=0,3S=0;6(h.2.1R>0){6(h.2.1F){a=1q.34(h.Z.1e/t())}11{5U(3R<h.Z.1e){++a;3R=3S+r();3S+=h.2.1R<=r()?h.2.1R:r()}}}11{a=1q.34(h.Z.1e/r())}14 a};9 t=8(){6(h.2.1R>0&&h.2.1R<=r()){14 h.2.1R}14 r()};9 u=8(){9 a,1P,2r;6(h.Z.1e>h.2.1k&&h.12.1K&&!h.2.1F){6(h.2.16===\'1h\'){1P=h.Z.1K();a=1P.19();v(-(a.1i-(h.13.1w()-1P.2s())),\'1j\',0)}11 6(h.2.16===\'1B\'){2r=h.Z.1e-h.2.1v;a=h.Z.1d(2r).19();v(-a.1f,\'1j\',0)}}11{a=h.Z.1d(h.12.15*t()).19();6(h.12.15===s()-1){h.12.1K=17}6(a!==1I){6(h.2.16===\'1h\'){v(-a.1i,\'1j\',0)}11 6(h.2.16===\'1B\'){v(-a.1f,\'1j\',0)}}}};9 v=8(a,b,c,d){9 f,2I;6(h.2Z){2I=h.2.16===\'1B\'?\'4T(0, \'+a+\'4U, 0)\':\'4T(\'+a+\'4U, 0, 0)\';7.1c(\'-\'+h.2o+\'-3G-5V\',c/4I+\'s\');6(b===\'2t\'){7.1c(h.2c,2I);6(c!==0){7.1V(\'35 36 38 3a\',8(e){6(!$(e.4V).4W(7)){14}7.1W(\'35 36 38 3a\');H()})}11{H()}}11 6(b===\'1j\'){7.1c(h.2c,2I)}11 6(b===\'1z\'){7.1c(\'-\'+h.2o+\'-3G-4J-8\',\'4X\');7.1c(h.2c,2I);6(c!==0){7.1V(\'35 36 38 3a\',8(e){6(!$(e.4V).4W(7)){14}7.1W(\'35 36 38 3a\');v(d.2h,\'1j\',0);M()})}11{v(d.2h,\'1j\',0);M()}}}11{f={};f[h.2c]=a;6(b===\'2t\'){7.3b(f,c,h.2.2l,8(){H()})}11 6(b===\'1j\'){7.1c(h.2c,a)}11 6(b===\'1z\'){7.3b(f,c,\'4X\',8(){v(d.2h,\'1j\',0);M()})}}};9 w=8(){9 a=\'\',2J=\'\',4Y=s();3B(9 i=0;i<4Y;i++){2J=\'\';6(h.2.2U&&$.5W(h.2.2U)||h.2.28){2J=h.2.2U(i);h.1E.1s(\'1b-5X-1u\')}11{2J=i+1;h.1E.1s(\'1b-5Y-1u\')}a+=\'<1m 1r="1b-1u-3T"><a 2K="" 1A-2t-15="\'+i+\'" 1r="1b-1u-5Z">\'+2J+\'</a></1m>\'}h.1E.2L(a)};9 x=8(){6(!h.2.28){h.1E=$(\'<1m 1r="1b-1u" />\');6(h.2.3r){$(h.2.3r).2L(h.1E)}11{h.Y.7.1s(\'1b-3U-1u\').1D(h.1E)}w()}11{h.1E=$(h.2.28)}h.1E.3c(\'25 2u\',\'a\',F)};9 y=8(){h.Y.1l=$(\'<a 1r="1b-1l" 2K="">\'+h.2.4s+\'</a>\');h.Y.1x=$(\'<a 1r="1b-1x" 2K="">\'+h.2.4t+\'</a>\');h.Y.1l.1V(\'25 2u\',B);h.Y.1x.1V(\'25 2u\',C);6(h.2.2V){$(h.2.2V).1D(h.Y.1l)}6(h.2.2W){$(h.2.2W).1D(h.Y.1x)}6(!h.2.2V&&!h.2.2W){h.Y.3V=$(\'<1m 1r="1b-Y-4Z" />\');h.Y.3V.1D(h.Y.1x).1D(h.Y.1l);h.Y.7.1s(\'1b-3U-Y-4Z\').1D(h.Y.3V)}};9 z=8(){h.Y.1n=$(\'<1m 1r="1b-Y-1G-3T"><a 1r="1b-1n" 2K="">\'+h.2.4u+\'</a></1m>\');h.Y.2i=$(\'<1m 1r="1b-Y-1G-3T"><a 1r="1b-2i" 2K="">\'+h.2.4v+\'</a></1m>\');h.Y.1L=$(\'<1m 1r="1b-Y-1G" />\');h.Y.1L.3c(\'25\',\'.1b-1n\',D);h.Y.1L.3c(\'25\',\'.1b-2i\',E);6(h.2.3s){h.Y.1L.1D(h.Y.1n)}11{h.Y.1L.1D(h.Y.1n).1D(h.Y.2i)}6(h.2.3t){$(h.2.3t).2L(h.Y.1L)}11{h.Y.7.1s(\'1b-3U-Y-1G\').1D(h.Y.1L)}I(h.2.3u?\'2i\':\'1n\')};9 A=8(){h.Z.1N(8(a){9 b=$(18).1O(\'3I:2H\').1J(\'60\');6(b!==1I&&(\'\'+b).1e){$(18).1D(\'<1m 1r="1b-51"><52>\'+b+\'</52></1m>\')}})};9 B=8(e){e.1X();6(h.Y.7.3d(\'1p\')){14}6(h.2.1G&&h.2.2Y){7.1Y()}7.2M()};9 C=8(e){e.1X();6(h.Y.7.3d(\'1p\')){14}6(h.2.1G&&h.2.2Y){7.1Y()}7.2N()};9 D=8(e){7.2v();e.1X()};9 E=8(e){7.1Y();e.1X()};9 F=8(e){9 a,3e;e.1X();6(h.Y.7.3d(\'1p\')){14}6(h.2.1G&&h.2.2Y){7.1Y()}a=$(e.61);6(a.1J(\'1A-2t-15\')!==1I){3e=2a(a.1J(\'1A-2t-15\'));6(3e!==h.12.15){7.3f(3e)}}};9 G=8(b){9 c=h.Z.1e;6(h.2.4q===\'62\'){6(h.2.1k>1){c=1q.34(h.Z.1e/h.2.1k)}h.1E.2L((b+1)+h.2.4r+c);14}h.1E.1O(\'a\').1Q(\'12\');h.1E.1N(8(i,a){$(a).1O(\'a\').1d(b).1s(\'12\')})};9 H=8(){6(h.2.1F){9 a=\'\';6(h.12.15===0){a=h.Z.1d(0).19()}11 6(h.12.15===s()-1&&h.2b){a=h.Z.1d((s()-1)*t()).19()}11 6(h.12.15===h.Z.1e-1){a=h.Z.1d(h.Z.1e-1).19()}6(a){6(h.2.16===\'1h\'){v(-a.1i,\'1j\',0)}11 6(h.2.16===\'1B\'){v(-a.1f,\'1j\',0)}}}h.1U=1a;h.2.4C.2q(7,h.Z.1d(h.12.15),h.2j,h.12.15)};9 I=8(a){6(h.2.3s){h.Y.1L.2L(h.Y[a])}11{h.Y.1L.1O(\'a\').1Q(\'12\');h.Y.1L.1O(\'a:3J(.1b-\'+a+\')\').1s(\'12\')}};9 J=8(){6(s()===1){h.Y.1x.1s(\'1p\');h.Y.1l.1s(\'1p\')}11 6(!h.2.1F&&h.2.4c){6(h.12.15===0){h.Y.1x.1s(\'1p\');h.Y.1l.1Q(\'1p\')}11 6(h.12.15===s()-1){h.Y.1l.1s(\'1p\');h.Y.1x.1Q(\'1p\')}11{h.Y.1x.1Q(\'1p\');h.Y.1l.1Q(\'1p\')}}};9 K=8(){6(h.2.3v>0){9 a=53(7.2v,h.2.3v)}11{7.2v();$(1S).63(8(){7.2v()}).64(8(){7.1Y()})}6(h.2.4x){7.3W(8(){6(h.22){7.1Y(17);h.3X=17}},8(){6(h.3X){7.2v(17);h.3X=1y}})}};9 L=8(){9 b=0,19,2B,1t,3Y,2O,3g,2P,1Z;6(h.2.2X===\'1l\'){7.1D(h.Z.1C().1s(\'1b-1C\'))}11{7.3E(h.Z.1C().1s(\'1b-1C\'));19=h.Z.2H().19();b=h.2.16===\'1h\'?-19.1i:-19.1f}v(b,\'1j\',0);h.2.1u=1a;h.2.Y=1a;h.2.2m=1a;6(h.2.4g){6(h.2Z){3Y=h.2.16===\'1h\'?4:5;h.13.3W(8(){2B=7.1c(\'-\'+h.2o+\'-2B\');1t=2f(2B.65(\',\')[3Y]);v(1t,\'1j\',0)},8(){1Z=0;h.Z.1N(8(a){1Z+=h.2.16===\'1h\'?$(18).2s(17):$(18).2F(17)});2O=h.2.26/1Z;3g=h.2.16===\'1h\'?\'1i\':\'1f\';2P=2O*(1Z-(1q.2w(2a(1t))));M(2P)})}11{h.13.3W(8(){7.2i()},8(){1Z=0;h.Z.1N(8(a){1Z+=h.2.16===\'1h\'?$(18).2s(17):$(18).2F(17)});2O=h.2.26/1Z;3g=h.2.16===\'1h\'?\'1i\':\'1f\';2P=2O*(1Z-(1q.2w(2a(7.1c(3g)))));M(2P)})}}M()};9 M=8(a){9 b=a?a:h.2.26,19={1i:0,1f:0},1j={1i:0,1f:0},3Z,2h,40;6(h.2.2X===\'1l\'){19=7.1O(\'.1b-1C\').2H().19()}11{1j=h.Z.2H().19()}3Z=h.2.16===\'1h\'?-19.1i:-19.1f;2h=h.2.16===\'1h\'?-1j.1i:-1j.1f;40={2h:2h};v(3Z,\'1z\',b,40)};9 N=8(a){9 b=$(1S),13={1f:b.66(),1i:b.67()},20=a.68();13.3h=13.1i+b.1w();13.2g=13.1f+b.1T();20.3h=20.1i+a.2s();20.2g=20.1f+a.2F();14(!(13.3h<20.1i||13.1i>20.3h||13.2g<20.1f||13.1f>20.2g))};9 O=8(e){9 a=30.69.6a.4H(),54=\'6b|6c\',p=6d 6e(a,[\'i\']),55=p.6f(54);6(55==1y&&N(7)){6(e.56===39){B(e);14 1a}11 6(e.56===37){C(e);14 1a}}};9 P=8(){h.1g={1n:{x:0,y:0},2k:{x:0,y:0}};h.13.1V(\'6g 6h 6i\',Q);h.13.3c(\'25\',\'.6j a\',8(e){6(h.13.3d(\'25-1p\')){e.1X();h.13.1Q(\'25-1p\')}})};9 Q=8(e){h.Y.7.1s(\'1p\');6(h.1U){e.1X();h.Y.7.1Q(\'1p\')}11{h.1g.2x=7.19();9 a=e.41,1M=(2Q a.2y!==\'1I\')?a.2y:[a];h.1g.1n.x=1M[0].3i;h.1g.1n.y=1M[0].3j;6(h.13.2e(0).57){h.2R=a.2R;h.13.2e(0).57(h.2R)}h.13.1V(\'42 43 44\',S);h.13.1V(\'2u 45 46\',T);h.13.1V(\'58 59\',R)}};9 R=8(e){v(h.1g.2x.1i,\'1j\',0);h.Y.7.1Q(\'1p\');h.13.1W(\'58 59\',R);h.13.1W(\'42 43 44\',S);h.13.1W(\'2u 45 46\',T);6(h.13.2e(0).3k){h.13.2e(0).3k(h.2R)}};9 S=8(e){9 a=e.41,1M=(2Q a.2y!==\'1I\')?a.2y:[a],47=1q.2w(1M[0].3i-h.1g.1n.x),48=1q.2w(1M[0].3j-h.1g.1n.y),1t=0,2S=0;6((47*3)>48&&h.2.4n){e.1X()}11 6((48*3)>47&&h.2.4o){e.1X()}6(h.2.16!==\'2n\'&&h.2.4m){6(h.2.16===\'1h\'){2S=1M[0].3i-h.1g.1n.x;1t=h.1g.2x.1i+2S}11{2S=1M[0].3j-h.1g.1n.y;1t=h.1g.2x.1f+2S}v(1t,\'1j\',0)}};9 T=8(e){h.13.1W(\'42 43 44\',S);h.Y.7.1Q(\'1p\');9 a=e.41,1M=(2Q a.2y!==\'1I\')?a.2y:[a],1t=0,21=0;h.1g.2k.x=1M[0].3i;h.1g.2k.y=1M[0].3j;6(h.2.16===\'2n\'){21=1q.2w(h.1g.1n.x-h.1g.2k.x);6(21>=h.2.3p){6(h.1g.1n.x>h.1g.2k.x){7.2M()}11{7.2N()}7.1Y()}}11{6(h.2.16===\'1h\'){21=h.1g.2k.x-h.1g.1n.x;1t=h.1g.2x.1i}11{21=h.1g.2k.y-h.1g.1n.y;1t=h.1g.2x.1f}6(!h.2.1F&&((h.12.15===0&&21>0)||(h.12.1K&&21<0))){v(1t,\'1j\',5a)}11{6(1q.2w(21)>=h.2.3p){6(21<0){7.2M()}11{7.2N()}7.1Y()}11{v(1t,\'1j\',5a)}}}h.13.1W(\'2u 45 46\',T);6(h.13.2e(0).3k){h.13.2e(0).3k(h.2R)}};9 U=8(e){6(!h.32){14}6(h.1U){1S.53(U,10)}11{9 a=$(1S).1w(),49=$(1S).1T();6(3w!==a||3x!==49){3w=a;3x=49;7.3N();h.2.4F.2q(7,h.12.15)}}};9 V=8(a){9 b=r();6(h.2.2A&&!h.2.1z){h.Z.1J(\'2C-2D\',\'17\');h.Z.3L(a,a+b).1J(\'2C-2D\',\'1a\')}};9 W=8(a){6(a<0){6(h.2.1F){14 s()-1}11{14 h.12.15}}11 6(a>=s()){6(h.2.1F){14 0}11{14 h.12.15}}11{14 a}};7.3f=8(a,b){9 c=17,4a=0,19={1i:0,1f:0},1P=1y,2r,1d,1t,4b;h.2j=h.12.15;h.12.15=W(a);6(h.1U||h.12.15===h.2j){14}h.1U=17;c=h.2.4B.2q(7,h.Z.1d(h.12.15),h.2j,h.12.15);6(2Q(c)!==\'1I\'&&!c){h.12.15=h.2j;h.1U=1a;14}6(b===\'1l\'){6(!h.2.4D.2q(7,h.Z.1d(h.12.15),h.2j,h.12.15)){c=1a}}11 6(b===\'1x\'){6(!h.2.4E.2q(7,h.Z.1d(h.12.15),h.2j,h.12.15)){c=1a}}h.12.1K=h.12.15>=s()-1;6(h.2.1u||h.2.28){G(h.12.15)}6(h.2.Y){J()}6(h.2.16===\'2n\'){6(h.2.2z&&h.13.1T()!==n()){h.13.3b({1T:n()},h.2.3m)}h.Z.6k(\':4j\').6l(h.2.26).1c({2E:0});h.Z.1d(h.12.15).1c(\'2E\',h.2.2T+1).6m(h.2.26,8(){$(18).1c(\'2E\',h.2.2T);H()})}11{6(h.2.2z&&h.13.1T()!==n()){h.13.3b({1T:n()},h.2.3m)}6(!h.2.1F&&h.2b&&h.12.1K){6(h.2.16===\'1h\'){1P=h.Z.1d(h.Z.1e-1);19=1P.19();4a=h.13.1w()-1P.2s()}11{2r=h.Z.1e-h.2.1v;19=h.Z.1d(2r).19()}}11 6(h.2b&&h.12.1K&&b===\'1x\'){1d=h.2.1R===1?h.2.1k-t():((s()-1)*t())-(h.Z.1e-h.2.1k);1P=7.Z(\'.1b-1C\').1d(1d);19=1P.19()}11 6(b===\'1l\'&&h.12.15===0){19=7.1O(\'> .1b-1C\').1d(h.2.1k).19();h.12.1K=1a}11 6(a>=0){4b=a*2a(t());19=h.Z.1d(4b).19()}6(2Q(19)!==\'1I\'){1t=h.2.16===\'1h\'?-(19.1i-4a):-19.1f;v(1t,\'2t\',h.2.26)}11{h.1U=1a}}6(h.2.2A){V(h.12.15*t())}};7.2M=8(){6(!h.2.1F&&h.12.1K){14}9 a=2a(h.12.15)+1;7.3f(a,\'1l\')};7.2N=8(){6(!h.2.1F&&h.12.15===0){14}9 a=2a(h.12.15)-1;7.3f(a,\'1x\')};7.2v=8(a){6(h.22){14}h.22=6n(8(){6(h.2.2X===\'1l\'){7.2M()}11{7.2N()}},h.2.4w);6(h.2.2m&&a!==17){I(\'2i\')}};7.1Y=8(a){6(!h.22){14}5b(h.22);h.22=1y;6(h.2.2m&&a!==17){I(\'1n\')}};7.6o=8(){14 h.12.15};7.6p=8(){14 h.Z.1d(h.12.15)};7.6q=8(a){14 h.Z.1d(a)};7.6r=8(){14 h.Z.1e};7.6s=8(){14 h.1U};7.3N=8(){h.Z.3O(7.1O(\'.1b-1C\')).2s(q());h.13.1c(\'1T\',n());6(!h.2.1z){u()}6(h.12.1K){h.12.15=s()-1}6(h.12.15>=s()){h.12.1K=17}6(h.2.1u&&!h.2.28){w();G(h.12.15)}6(h.2.2A){V(h.12.15*t())}};7.5c=8(){6(!h.32){14}h.32=1a;$(\'.1b-1C\',18).23();h.Z.1N(8(){6($(18).1A(\'2p\')!==1I){$(18).1J(\'2d\',$(18).1A(\'2p\'))}11{$(18).5d(\'2d\')}});6($(18).1A(\'2p\')!==1I){18.1J(\'2d\',$(18).1A(\'2p\'))}11{$(18).5d(\'2d\')}$(18).5e().5e();6(h.Y.7){h.Y.7.23()}6(h.Y.1l){h.Y.1l.23()}6(h.Y.1x){h.Y.1x.23()}6(h.1E&&h.2.Y&&!h.2.28){h.1E.23()}$(\'.1b-51\',18).23();6(h.Y.1L){h.Y.1L.23()}5b(h.22);6(h.2.3o){$(1S).1W(\'4Q\',U)}6(h.2.3q){$(30).1W(\'4R\',O)}$(18).6t(\'29\')};7.6u=8(a){6(a!==1I){g=a}7.5c();j();$(7).1A(\'29\',18)};j();$(7).1A(\'29\',18);14 18}})(6v);', 62, 404, '||settings||||if|el|function|var|||||||||||||||||||||||||||||||||||||||||||||||||||controls|children||else|active|viewport|return|index|mode|true|this|position|false|bx|css|eq|length|top|touch|horizontal|left|reset|maxSlides|next|div|start|slideMargin|disabled|Math|class|addClass|value|pager|minSlides|width|prev|null|ticker|data|vertical|clone|append|pagerEl|infiniteLoop|auto|slideWidth|undefined|attr|last|autoEl|touchPoints|each|find|lastChild|removeClass|moveSlides|window|height|working|bind|unbind|preventDefault|stopAuto|totalDimens|bounds|distance|interval|remove|wrapWidth|click|speed|startSlide|pagerCustom|bxSlider|parseInt|carousel|animProp|style|get|parseFloat|bottom|resetValue|stop|oldIndex|end|easing|autoControls|fade|cssPrefix|origStyle|call|lastShowingIndex|outerWidth|slide|touchend|startAuto|abs|originalPos|changedTouches|adaptiveHeight|ariaHidden|transform|aria|hidden|zIndex|outerHeight|padding|first|propValue|linkContent|href|html|goToNextSlide|goToPrevSlide|ratio|newSpeed|typeof|pointerId|change|slideZIndex|buildPager|nextSelector|prevSelector|autoDirection|stopAutoOnClick|usingCSS|document|props|initialized|box|ceil|transitionend|webkitTransitionEnd||oTransitionEnd||MSTransitionEnd|animate|on|hasClass|pagerIndex|goToSlide|property|right|pageX|pageY|releasePointerCapture|slideSelector|adaptiveHeightSpeed|preloadImages|responsive|swipeThreshold|keyboardEnabled|pagerSelector|autoControlsCombine|autoControlsSelector|autoStart|autoDelay|windowWidth|windowHeight|floor|minThreshold|maxThreshold|for|parent|loader|prepend|relative|transition|none|img|not|sliceAppend|slice|slicePrepend|redrawSlider|add|border|childWidth|breakPoint|counter|item|has|directionEl|hover|autoPaused|idx|animateProperty|params|originalEvent|touchmove|MSPointerMove|pointermove|MSPointerUp|pointerup|xMovement|yMovement|windowHeightNew|moveBy|requestEl|hideControlOnEnd|500|randomStart|captions|tickerHover|video|useCSS|visible|wrapperClass|touchEnabled|oneToOneTouch|preventDefaultSwipeX|preventDefaultSwipeY|ariaLive|pagerType|pagerShortSeparator|nextText|prevText|startText|stopText|pause|autoHover|autoSlideForOnePage|shrinkItems|onSliderLoad|onSlideBefore|onSlideAfter|onSlideNext|onSlidePrev|onSliderResize|all|toLowerCase|1000|timing|100|display|src|iframe|count|load|resize|keydown|sizing|translate3d|px|target|is|linear|pagerQty|direction||caption|span|setTimeout|tagFilters|result|keyCode|setPointerCapture|MSPointerCancel|pointercancel|200|clearInterval|destroySlider|removeAttr|unwrap|wrapper|full|Next|Prev|Start|Stop|4000|fn|extend|random|createElement|WebkitPerspective|MozPerspective|OPerspective|msPerspective|replace|Perspective|wrap|live|polite|loading|215|swing|overflow|maxWidth|margin|0px|float|listStyle|marginRight|marginBottom|absolute|block|fitVids|after|one|error|complete|max|apply|map|while|duration|isFunction|custom|default|link|title|currentTarget|short|focus|blur|split|scrollTop|scrollLeft|offset|activeElement|tagName|input|textarea|new|RegExp|exec|touchstart|MSPointerDown|pointerdown|bxslider|filter|fadeOut|fadeIn|setInterval|getCurrentSlide|getCurrentSlideElement|getSlideElement|getSlideCount|isWorking|removeData|reloadSlider|jQuery'.split('|'), 0, {}));
/*!
	jQuery.browser.mobile
	Copyright	Chad Smith
	License		Unlicense
	Version		0.4.0

	http://detectmobilebrowser.com
*/
(function (a) { (jQuery.browser = jQuery.browser || {}).mobile = /(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od|ad)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows ce|xda|xiino/i.test(a) || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(a.substr(0, 4)) })(navigator.userAgent || navigator.vendor || window.opera);
/*!
 * Scripts
 */
head.ready(function () {
    (function (globals) {
        "use strict";
        globals.GLOB = {};
    }((1, eval)('this')));
    var $ = jQuery.noConflict();
    var Default = {
        utils: {
            links: function () {
                $('a[rel*=external]').on('click', function (e) {
                    e.preventDefault();
                    window.open($(this).attr('href'));
                });
            },
            mails: function () {
                $('.email:not(:input, div)').each(function (index) {
                    em = $(this).text().replace('//', '@').replace(/\//g, '.');
                    $(this).text(em).attr('href', 'mailto:' + em);
                });
                $('.social-b a.email').wrapInner('<span class="inner"></span>').prepend('<i class="icon-envelope"></i>');
            },
            forms: function () {
                $('.form-a label:not(.hidden) + :input:not(select,button), #aside .search label:not(.hidden) + :input:not(select,button)').each(function () {
                    $(this).attr('placeholder', $(this).parent().children('label').text()).parent().children('label').addClass('hidden');
                });

                xa = $('form > *, fieldset > *');
                xb = parseInt(xa.length);
                xa.each(function () { $(this).css('z-index', xb); xb--; });

                $('#aside input[type="checkbox"], #aside input[type="radio"]').parents('li').addClass('checks');

                $('input[type="checkbox"][checked], input[type="radio"][checked]').each(function () { $(this).attr('checked', true).parent('label').addClass('active'); });
                $('input[type="checkbox"]:not([checked]), input[type="radio"]:not([checked])').attr('checked', false);
                $('#aside .checks label').append('<div class="input"></div>').each(function () { $(this).addClass($(this).children('input').attr('type')); }).children('input').addClass('hidden').on('click', function () {
                    if ($(this).parent().hasClass('radio')) {
                        $(this).parent('label').parents('p,ul').find('label').removeClass('active');
                    }
                    $(this).parent('label').toggleClass('active');
                });
            },
            date: function () {
                $('#footer .date').text((new Date).getFullYear());
            },
            top: function () {
                $('#nav > ul').parents('#top').append('<div class="menu"><div class="a"></div><div class="b"></div><div class="c"></div></div>');
                $('#nav > ul > li > ul, #aside li > ul').before('<span class="toggle"></span>').parent().addClass('sub');
                $('#top > .menu').on('click', function () { $('html').toggleClass('menu-active'); return false });

                $('#nav li.sub > .toggle').on('click', function () { if ($(this).parent().hasClass('toggle')) { $(this).parent().removeClass('toggle'); } else { $(this).parent().parent().find('li').removeClass('toggle'); $(this).parent().addClass('toggle'); } });
                $('#aside li.sub > a').on('click', function () { $(this).parent().toggleClass('toggle'); return false });
            },
            maps: function () {
                $('#map').append('<div class="inner"></div>');
                $('#map > .inner').attr('id', 'mapa');
                if ($('#map').size()) {
                    var mapa, styledMap, mapOptions, styles, markerOpts, infowindow;
                    styledMap = new google.maps.StyledMapType(styles, { name: 'Styled Map' });

                    mapOptions = {
                        zoom: 17,
                        center: new google.maps.LatLng(50.8438881, 4.384093099999973),
                        mapTypeId: google.maps.MapTypeId.SATELLITE,
                        disableDefaultUI: true,
                        draggable: true,
                        zoomControl: true,
                        scrollwheel: false,
                        disableDoubleClickZoom: false,
                        mapTypeControlOptions: {
                            mapTypeIds: [google.maps.MapTypeId.ROADMAP, 'map_style']
                        }
                    };
                    mapa = new google.maps.Map(document.getElementById('mapa'), mapOptions);

                    mapa.mapTypes.set('map_style', styledMap);
                    mapa.setMapTypeId('map_style');

                    markerOpts = {
                        position: new google.maps.LatLng(50.8438881, 4.384093099999973),
                        map: mapa
                    }
                    new google.maps.Marker(markerOpts);
                }
            },
            popups: function () {
                $('*[class^=popup]').wrapInner('<div class="box-outer"><div class="box-inner"><div class="box-inset"></div></div></div>');
                $('*[class^=popup] .box-outer, *[class^=popup] .box-inset').append('<a class="close">Close</a>');
                $('*[class^=popup] .box-inner').each(function () {
                    if ($(this).outerHeight() > $(window).height()) {
                        $(this).addClass('absolute').parents('.popup-a').addClass('absolute');
                    } else {
                        $(this).removeClass('absolute').parents('.popup-a').removeClass('absolute');
                    }
                });

                function prepareUrl(str) {
                    str = str == undefined ? '' : str;
                    str = str.toLowerCase();
                    str = str.replace(/ /g, '-');
                    str = str.replace(/'/g, '-');
                    return str;
                }
                function removeHash() {
                    if ('pushState' in history) { history.pushState('', document.title, window.location.pathname + window.location.search); }
                    else { window.location = window.location.href.replace(/#.*/, ""); }
                }
                function setUrl(url) { window.location.hash = '!' + prepareUrl(url); return true; }

                var $trg = 0;
                $('a[data-popup]').on('click', function () {
                    $('*[class^=popup]').removeClass('shown');
                    $trg = $('*[class^=popup][title="' + $(this).attr('data-popup') + '"]');
                    setUrl($trg.attr('title'));
                    $trg.addClass('shown');
                    $('html').addClass('popup-shown');
                    return false
                });

                $('*[class^=popup] .close').on('click', function () { $('*[class^=popup]').removeClass('shown').parents('html').removeClass('popup-shown'); removeHash(); });
                $(window).on('keydown', function (e) { if (e.which == 27) { $('*[class^=popup]').removeClass('shown').parents('html').removeClass('popup-shown'); removeHash(); } });
                if (document.location.hash.length) {
                    $('a[data-popup="' + document.location.hash.substring(2) + '"]').click();
                    $('*[class^=popup].shown').parents('html').addClass('popup-shown');
                }
            },
            team: function () {
                $('.list-b [data-popup] > div').each(function () { $(this).clone().prepend('<header>' + $(this).parent().children('header').html() + '</header>').attr('title', $(this).parent().attr('data-popup')).addClass('popup-a a').insertAfter('#content'); $(this).parents('li').append('<a class="open-popup" data-popup="' + $(this).parent().attr('data-popup') + '"></a>'); }).after('<a class="more mobile-only"><span>More</span> <span class="hidden">Less</span></a>');
                $('.list-b a.more').on('click', function () { $(this).toggleClass('toggle').children().toggleClass('hidden').parents('li').toggleClass('toggle'); return false });
            },
            scrolling: function () {
                if (!$.browser.mobile) {
                    $(window).on('load scroll', function () {
                        if ($(window).scrollTop() <= 0) {
                            $('html').removeClass('not-top');
                        } else {
                            $('html').addClass('not-top');
                        }
                    });
                }
            },
            onload: function () {
                //$('html').addClass('run');
            },
            offclick: function () {
                $('html').on('click', function () {
                    $('.list-i-wrapper.toggle').removeClass('toggle');
                });
                $('.list-i-wrapper').on('click', function (event) { event.stopPropagation(); });
            },
            miscellaneous: function () {
                $('#featured figure, #root > figure:not(#map), .module-a > figure.background').addClass('has-background').each(function () { $(this).css({ 'background-image': 'url("' + $(this).find('img').attr('src') + '")' }); }).parents('.module-a').addClass('has-background');
                $('.float-left, .float-right').each(function () { $(this).addClass('mobile-hide').clone().removeClass('mobile-hide').addClass('mobile-only').appendTo($(this).parent()); });
                $('.double .vcard + .form-a').each(function () { $(this).prev().find(':header:first').addClass('mobile-hide').clone().removeClass('mobile-hide').addClass('mobile-only').prependTo($(this)); });
                $('#featured figure').prev().addClass('last-child');
                $('.gallery-a li').each(function () { $(this).clone().appendTo($(this).parent()); });
                $('.list-d').each(function () { if ($(this).children().size() > 1) { $(this).addClass('slider'); } });
                $('.gallery-a').each(function () { if ($(this).children().size() > 5) { $(this).addClass('slider'); } });
                $('.list-d.slider, .gallery-a.slider').wrapInner('<div class="inner"></div>');
                $('.list-c .more').wrapInner('<span class="inner"></span>');
                $('.list-d.slider > .inner').each(function () { $(this).bxSlider({ pager: true, controls: false, useCSS: false, adaptiveHeight: true }); });
                $('.gallery-a.slider > .inner').each(function () { $(this).bxSlider({ pager: false, controls: false, useCSS: false, adaptiveHeight: true, ticker: true, speed: 20000, minSlides: 5, maxSlides: 50 }); });
                $('.list-c li').on('click', function () { if ($(this).hasClass('toggle')) { $(this).removeClass('toggle'); } else { $(this).parent().find('li').removeClass('toggle'); $(this).addClass('toggle'); } }).append('<a class="link mobile-only"><span>More</span> <span class="hidden">Less</span></a>');
                $('.list-c a.link').on('click', function () { $(this).children().toggleClass('hidden').parents('li').toggleClass('active'); return false });
                $('.module-a figure.mobile-only').remove();
                $('.module-a figure.mobile-hide').removeClass('mobile-hide');
                $('#featured').addClass('regular').clone().removeClass('regular').addClass('sticky').insertAfter('#featured');
                $('.list-h .link a').each(function () { $(this).clone().addClass('clone').appendTo($(this).parents('li')); });
                $('.list-f li:last-child, .list-h ul li:last-child').prev().addClass('before-last');
                $('.list-h :header').each(function () { if ($(this).outerHeight() > 40) { $(this).parents('li').addClass('high'); }; });
                $('.list-h:not(.a) :header').each(function () { $(this).addClass('mobile-hide').clone().removeClass('mobile-hide').addClass('mobile-only').appendTo($(this).parents('li')); });
                $('.list-h .scheme-a').each(function () { $(this).clone().insertAfter($(this).parents('li').find(':header:first')); });
                $('.list-h .scheme-a').each(function () { $(this).clone().wrap('<li class="mobile-only"></li>').parent().prependTo($(this).parents('li').find('ul')); });
                $('.list-h li .scheme-a + .scheme-a, .list-h ul li.mobile-only + .mobile-only').remove();
                $('.list-h .label').each(function () { $(this).parents('li').find('ul').find('li.before-last').after('<li class="li-label">' + $(this).html() + '</li>'); });
                $('.list-i').each(function () { $(this).wrap('<div class="list-i-wrapper"></div>').before('<h2 class="mobile-only list-i-title">Status: <span class="inner">' + $(this).find('.active').find('a').html() + '</span></h2>'); });
                $('.list-i-title').on('click', function () { $(this).parents('.list-i-wrapper').toggleClass('toggle'); return false });
                $('#aside :header').on('click', function () { $(this).parents('#aside').toggleClass('toggle'); return false });
                $('#aside:not(.a) :header').each(function () { $(this).html($(this).parents('#aside').find('li.active').text()); });
                $('.module-c > .b footer .link-b').each(function () { $(this).addClass('mobile-hide').clone().removeClass('mobile-hide').addClass('mobile-only').insertAfter($(this).parents('.b').children('.double:first').children('*:first-child')); });
                $('#nav > p:only-child').clone().addClass('back').appendTo('#top');
            }
        },
        ie: {
            css: function () {
                $('html.lt-ie11').each(function () { $('input[placeholder], textarea[placeholder]').placeholder(); });
                $('html.lt-ie9').each(function () {
                    $('body').append('<p class="lt-ie9">Your browser is ancient! Please <a target="_blank" href="http://browsehappy.com/">upgrade your browser</a> to improve your experience.</p>').css('padding-top', '28px');
                    $(':last-child').addClass('last-child');
                });
            }
        }

    };

    Default.utils.links();
    Default.utils.mails();
    Default.utils.forms();
    Default.utils.date();
    Default.utils.team();
    Default.utils.miscellaneous();
    Default.utils.scrolling();
    Default.utils.popups();
    Default.utils.top();
    Default.utils.offclick();
    Default.ie.css();
    Default.utils.onload();

    window.initialize = function () { Default.utils.maps(); }
    var script = document.createElement('script');
    script.type = 'text/javascript';
    script.src = 'http://maps.google.com/maps/api/js?language=en&callback=initialize';
    document.body.appendChild(script);
});

/*!*/