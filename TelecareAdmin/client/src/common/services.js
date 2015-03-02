angular.module('telecareAdminServices', [])

.factory('participantsData', function() {
        var original = [{
            id: 1,
            name: 'Dorothy Drake',
            dob: new Date(1945, 8, 30),
            enrollmentDate: new Date(2015, 1, 9),
            activated: true,
            activationCode: 'JKMF-YXMQ-NFKN-YKGN-XNVQ',
            secretQuestion: 'Favourite food',
            secretAnswer: 'Pizza'
        }, {
            id: 2,
            name: 'Alan Ingham',
            dob: new Date(1941, 2, 14),
            enrollmentDate: new Date(2014, 10, 30),
            activated: false,
            activationCode: 'JKMF-YXMQ-NFKN-YKGN-XNVQ',
            secretQuestion: 'Favourite food',
            secretAnswer: 'Pizza'
        }, {
            id: 3,
            name: 'Samantha Smith',
            dob: new Date(1974, 10, 23),
            enrollmentDate: new Date(2014, 8, 12),
            activated: true,
            activationCode: 'JKMF-YXMQ-NFKN-YKGN-XNVQ',
            secretQuestion: 'Favourite food',
            secretAnswer: 'Pizza'
        }, {
            id: 4,
            name: 'Kate Fisshure',
            dob: new Date(1942, 11, 12),
            enrollmentDate: new Date(2014, 9, 1),
            activated: true,
            activationCode: 'JKMF-YXMQ-NFKN-YKGN-XNVQ',
            secretQuestion: 'Favourite food',
            secretAnswer: 'Pizza'
        }, {
            name: 'Alan Manye',
            dob: new Date(1912, 5, 23),
            enrollmentDate: new Date(2012, 6, 27),
            activated: true,
            activationCode: 'KGUW-SGUD-WHFU-SNFH-PEIR',
            secretQuestion: 'Favourite movie',
            secretAnswer: 'The Theory of Everything'
        }, {
            name: 'Maria Johnson',
            dob: new Date(1934, 2, 13),
            enrollmentDate: new Date(2003, 7, 14),
            activated: false,
            activationCode: 'SHGS-WUWF-ABUE-GEHF-FHWF',
            secretQuestion: 'The Dog',
            secretAnswer: 'Pluto'
        }, {
            name: 'Carl Brick',
            dob: new Date(1985, 2, 9),
            enrollmentDate: new Date(2015, 0, 13),
            activated: true,
            activationCode: 'RDYF-AHGR-WRHF-SIFD-SUHR',
            secretQuestion: 'Holiday place',
            secretAnswer: 'Bexhill'
        }];

        var mocked = [{"activated":true,"secretQuestion":"Nulla ac enim.","secretAnswer":"adipiscing","name":"Leslie Haag","dob":new Date(1950, 0, 17),"enrollmentDate":new Date(2014, 2, 25),"activationCode":"BMSW-WTOS-LQZX-HMPL-FOIU"},
            {"activated":true,"secretQuestion":"In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem.","secretAnswer":"convallis duis","name":"Shelly Schmeler","dob":new Date(1924, 7, 12),"enrollmentDate":new Date(2014, 1, 19),"activationCode":"RDWK-WJVQ-YPRJ-JWHZ-OLEF"},
            {"activated":false,"secretQuestion":"Vivamus vestibulum sagittis sapien.","secretAnswer":"nec dui","name":"Calvin Runolfsdottir","dob":new Date(1939, 5, 11),"enrollmentDate":new Date(2014, 9, 19),"activationCode":"LRKX-XBOJ-EIUD-RTPJ-CHBX"},
            {"activated":false,"secretQuestion":"Cras in purus eu magna vulputate luctus.","secretAnswer":"at nibh","name":"Christiana Wisoky","dob":new Date(1906, 1, 12),"enrollmentDate":new Date(2012, 2, 21),"activationCode":"KIJN-VUIO-USIR-ZLER-BCLY"},
            {"activated":true,"secretQuestion":"Suspendisse potenti.","secretAnswer":"faucibus orci luctus","name":"Franklyn Olson","dob":new Date(1938, 5, 10),"enrollmentDate":new Date(2014, 3, 20),"activationCode":"ELFX-FDEP-PFCB-MDUG-LXYE"},
            {"activated":false,"secretQuestion":"Vivamus vel nulla eget eros elementum pellentesque.","secretAnswer":"platea dictumst aliquam","name":"Mariah Kiehn","dob":new Date(1974, 7, 23),"enrollmentDate":new Date(2013, 1, 29),"activationCode":"UVBD-QFNW-YNOR-VWKM-YFBR"},
            {"activated":true,"secretQuestion":"Nulla ac enim.","secretAnswer":"augue quam","name":"Enoch Wiegand","dob":new Date(1988, 8, 27),"enrollmentDate":new Date(2014, 5, 11),"activationCode":"YNXM-QCTY-NRFH-DNJL-BNOV"},
            {"activated":false,"secretQuestion":"In congue.","secretAnswer":"volutpat erat","name":"Nicolas Casper","dob":new Date(1925, 9, 10),"enrollmentDate":new Date(2013, 2, 16),"activationCode":"ELJY-WJRM-IMGA-HKLV-JROI"},
            {"activated":true,"secretQuestion":"Suspendisse potenti.","secretAnswer":"rutrum","name":"Jacob Gaylord","dob":new Date(1946, 5, 10),"enrollmentDate":new Date(2014, 9, 26),"activationCode":"BANE-XPQD-EKCQ-IXYE-FYLU"},
            {"activated":false,"secretQuestion":"Duis bibendum, felis sed interdum venenatis, turpis enim blandit mi, in porttitor pede justo eu massa.","secretAnswer":"libero quis orci","name":"Rosaria Ebert","dob":new Date(1952, 8, 23),"enrollmentDate":new Date(2014, 4, 29),"activationCode":"CPDZ-YXFM-TEWL-WXDV-WKHI"},
            {"activated":true,"secretQuestion":"Nulla neque libero, convallis eget, eleifend luctus, ultricies eu, nibh.","secretAnswer":"eu felis","name":"Pablo Robel","dob":new Date(1963, 1, 29),"enrollmentDate":new Date(2014, 5, 18),"activationCode":"ROHP-ROJQ-MEWK-NFAS-OLKT"},
            {"activated":true,"secretQuestion":"Praesent blandit lacinia erat.","secretAnswer":"at velit eu","name":"Jesenia Morar","dob":new Date(1935, 2, 13),"enrollmentDate":new Date(2012, 2, 17),"activationCode":"DKME-GESR-FEDG-SHPJ-VSLQ"},
            {"activated":false,"secretQuestion":"Mauris enim leo, rhoncus sed, vestibulum sit amet, cursus id, turpis.","secretAnswer":"volutpat in congue","name":"Olimpia Dickinson","dob":new Date(1913, 4, 16),"enrollmentDate":new Date(2012, 6, 12),"activationCode":"YCMU-GVEU-IGNV-PNVA-NGFA"},
            {"activated":false,"secretQuestion":"Donec ut dolor.","secretAnswer":"sociis natoque","name":"Doug Herzog","dob":new Date(1961, 2, 27),"enrollmentDate":new Date(2014, 8, 10),"activationCode":"ABCG-WNPR-QVUY-FDNQ-PCQJ"},
            {"activated":true,"secretQuestion":"Suspendisse potenti.","secretAnswer":"est lacinia nisi","name":"Eldridge Leannon","dob":new Date(1926, 8, 27),"enrollmentDate":new Date(2012, 8, 26),"activationCode":"PXIV-DHAY-DWLB-IXUN-EODM"},
            {"activated":true,"secretQuestion":"Nulla tellus.","secretAnswer":"at","name":"Kelvin Hessel","dob":new Date(1988, 7, 13),"enrollmentDate":new Date(2014, 2, 22),"activationCode":"KLAB-MJFA-ABSG-UEWH-GYER"},
            {"activated":false,"secretQuestion":"Morbi non lectus.","secretAnswer":"ac nibh fusce","name":"Gabriel Reynolds","dob":new Date(1964, 6, 12),"enrollmentDate":new Date(2012, 8, 15),"activationCode":"ELPB-FLAP-CVHK-HSNO-KXVU"},
            {"activated":true,"secretQuestion":"Suspendisse accumsan tortor quis turpis.","secretAnswer":"sapien","name":"Kathlyn Sanford","dob":new Date(1932, 9, 20),"enrollmentDate":new Date(2014, 6, 28),"activationCode":"TBMD-JFHB-KQNM-ECXR-YNQL"},
            {"activated":false,"secretQuestion":"Morbi porttitor lorem id ligula.","secretAnswer":"ultrices","name":"Anette Lowe","dob":new Date(1933, 6, 18),"enrollmentDate":new Date(2013, 2, 20),"activationCode":"GIUN-OFDI-VTDM-QOAY-HCOT"},
            {"activated":false,"secretQuestion":"Nunc purus.","secretAnswer":"quisque arcu","name":"Junior Champlin","dob":new Date(1993, 7, 26),"enrollmentDate":new Date(2014, 6, 20),"activationCode":"EHXS-IUAM-OAPQ-FZYE-HQBS"},
            {"activated":false,"secretQuestion":"Cras mi pede, malesuada in, imperdiet et, commodo vulputate, justo.","secretAnswer":"integer","name":"Terrance Stoltenberg","dob":new Date(1950, 6, 13),"enrollmentDate":new Date(2014, 2, 25),"activationCode":"DHAZ-RWFZ-MEKY-AXLK-MHCB"},
            {"activated":true,"secretQuestion":"Integer non velit.","secretAnswer":"in consequat","name":"Patrice Wiegand","dob":new Date(1924, 0, 24),"enrollmentDate":new Date(2012, 6, 28),"activationCode":"NZYV-KDAF-ARUL-XWCT-KELT"},
            {"activated":false,"secretQuestion":"In hac habitasse platea dictumst.","secretAnswer":"iaculis","name":"Elvis Strosin","dob":new Date(1994, 4, 17),"enrollmentDate":new Date(2014, 0, 16),"activationCode":"ONXZ-HZGS-CQKY-TQHI-VJMC"},
            {"activated":false,"secretQuestion":"Nulla mollis molestie lorem.","secretAnswer":"augue vestibulum","name":"Emmitt Klocko","dob":new Date(1957, 5, 27),"enrollmentDate":new Date(2014, 4, 20),"activationCode":"KJGY-DALY-GKZE-DXNQ-BITQ"},
            {"activated":false,"secretQuestion":"Nulla neque libero, convallis eget, eleifend luctus, ultricies eu, nibh.","secretAnswer":"pede justo lacinia","name":"Bradley Ebert","dob":new Date(1992, 5, 12),"enrollmentDate":new Date(2014, 0, 15),"activationCode":"MFAX-DURH-RZMX-RTZY-KBZO"},
            {"activated":false,"secretQuestion":"Morbi odio odio, elementum eu, interdum eu, tincidunt in, leo.","secretAnswer":"lobortis est","name":"Mae Bayer","dob":new Date(1918, 5, 20),"enrollmentDate":new Date(2014, 5, 27),"activationCode":"TEZH-LSCO-GZND-EKJW-QWGP"},
            {"activated":true,"secretQuestion":"Nulla nisl.","secretAnswer":"turpis eget","name":"Zora Steuber","dob":new Date(1954, 8, 20),"enrollmentDate":new Date(2014, 9, 16),"activationCode":"ZOGH-JPYC-EYFQ-PGLA-CXYV"},
            {"activated":true,"secretQuestion":"Donec ut dolor.","secretAnswer":"quam","name":"Rudolph Schmidt","dob":new Date(1938, 7, 22),"enrollmentDate":new Date(2012, 1, 19),"activationCode":"NBVT-SKXG-GOVW-TRCF-LTRO"},
            {"activated":true,"secretQuestion":"Duis aliquam convallis nunc.","secretAnswer":"vivamus tortor duis","name":"Kimberely Johnson","dob":new Date(1936, 5, 14),"enrollmentDate":new Date(2013, 9, 25),"activationCode":"MVHK-MVDO-SUNC-VWUZ-UTSV"},
            {"activated":false,"secretQuestion":"Ut at dolor quis odio consequat varius.","secretAnswer":"nam","name":"Mallie Crooks","dob":new Date(1983, 8, 27),"enrollmentDate":new Date(2012, 7, 14),"activationCode":"CPGU-XZLS-BKEW-FUPI-UQLV"},
            {"activated":false,"secretQuestion":"In est risus, auctor sed, tristique in, tempus sit amet, sem.","secretAnswer":"mauris","name":"Sharleen Klein","dob":new Date(1977, 1, 10),"enrollmentDate":new Date(2014, 0, 19),"activationCode":"BQIY-QEWB-WXTY-FTAH-VMDH"},
            {"activated":false,"secretQuestion":"Sed accumsan felis.","secretAnswer":"ultrices posuere cubilia","name":"Tomoko Johnson","dob":new Date(1901, 8, 17),"enrollmentDate":new Date(2014, 0, 15),"activationCode":"ZFYN-TFCZ-BPLK-VTHO-VMNK"},
            {"activated":false,"secretQuestion":"Aenean auctor gravida sem.","secretAnswer":"ultrices vel augue","name":"Katherina Altenwerth","dob":new Date(1947, 5, 15),"enrollmentDate":new Date(2013, 8, 22),"activationCode":"THVJ-NDBE-YMWR-XEUK-ZJGY"},
            {"activated":true,"secretQuestion":"Suspendisse potenti.","secretAnswer":"nibh fusce","name":"Machelle Koch","dob":new Date(1938, 6, 12),"enrollmentDate":new Date(2014, 4, 15),"activationCode":"BSOU-RQYC-YLWA-GXPQ-XNUQ"},
            {"activated":false,"secretQuestion":"Phasellus in felis.","secretAnswer":"suspendisse accumsan tortor","name":"Enrique Herman","dob":new Date(1909, 8, 21),"enrollmentDate":new Date(2011, 9, 24),"activationCode":"CTLF-CTEI-UZEY-TNLY-CZMG"},
            {"activated":true,"secretQuestion":"Aenean auctor gravida sem.","secretAnswer":"tellus","name":"Esta Hudson","dob":new Date(1921, 0, 19),"enrollmentDate":new Date(2014, 5, 13),"activationCode":"ROQN-DLCA-MASC-FRXA-ZEIJ"},
            {"activated":false,"secretQuestion":"Donec diam neque, vestibulum eget, vulputate ut, ultrices vel, augue.","secretAnswer":"tincidunt","name":"Stormy Bartell","dob":new Date(1997, 3, 13),"enrollmentDate":new Date(2013, 7, 27),"activationCode":"OKTB-EQZJ-XESQ-UOTZ-OYFW"},
            {"activated":false,"secretQuestion":"Nulla ac enim.","secretAnswer":"sit amet turpis","name":"Maryland Reilly","dob":new Date(1968, 5, 16),"enrollmentDate":new Date(2014, 1, 11),"activationCode":"ISNQ-INZO-VGPW-TANB-GVZX"},
            {"activated":false,"secretQuestion":"Maecenas rhoncus aliquam lacus.","secretAnswer":"in","name":"Kiyoko Ebert","dob":new Date(1940, 2, 10),"enrollmentDate":new Date(2013, 4, 23),"activationCode":"VOWQ-EMKU-NTGX-UNWO-SHDP"},
            {"activated":true,"secretQuestion":"Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est.","secretAnswer":"in sagittis dui","name":"Isaias Gleichner","dob":new Date(1901, 8, 29),"enrollmentDate":new Date(2014, 4, 29),"activationCode":"HYOP-RMIQ-VRPB-DYNK-OBQM"},
            {"activated":true,"secretQuestion":"Suspendisse accumsan tortor quis turpis.","secretAnswer":"phasellus in felis","name":"Eddie Ritchie","dob":new Date(1928, 8, 16),"enrollmentDate":new Date(2014, 3, 27),"activationCode":"AMVQ-GYQP-TOWG-CXZR-BHJU"},
            {"activated":false,"secretQuestion":"Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Duis faucibus accumsan odio.","secretAnswer":"eget massa","name":"Jess Romaguera","dob":new Date(1980, 1, 20),"enrollmentDate":new Date(2013, 2, 11),"activationCode":"HRPM-RKEG-UCQV-CQJB-IMOX"},
            {"activated":true,"secretQuestion":"Donec semper sapien a libero.","secretAnswer":"enim sit","name":"Annmarie Ortiz","dob":new Date(1977, 6, 18),"enrollmentDate":new Date(2014, 8, 28),"activationCode":"LVMH-JFHM-MCHF-QOGX-NAUR"},
            {"activated":true,"secretQuestion":"Maecenas tincidunt lacus at velit.","secretAnswer":"nec nisi","name":"Pablo Wolff","dob":new Date(1990, 2, 13),"enrollmentDate":new Date(2014, 3, 24),"activationCode":"MBGE-RIZG-QHFP-DNBH-QKVM"},
            {"activated":false,"secretQuestion":"Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.","secretAnswer":"ante","name":"Janyce Howell","dob":new Date(1985, 4, 24),"enrollmentDate":new Date(2013, 4, 21),"activationCode":"SCBK-CLUG-RBXS-HLTS-SBZL"},
            {"activated":true,"secretQuestion":"Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem.","secretAnswer":"massa","name":"Aldo Walker","dob":new Date(1945, 7, 12),"enrollmentDate":new Date(2014, 8, 14),"activationCode":"MZPW-VACW-SNVF-HTKG-QDSK"},
            {"activated":false,"secretQuestion":"Phasellus in felis.","secretAnswer":"justo sollicitudin","name":"Cory Sipes","dob":new Date(1913, 3, 25),"enrollmentDate":new Date(2014, 2, 26),"activationCode":"BJME-MNGC-BGWA-LZRY-HKUE"},
            {"activated":false,"secretQuestion":"Integer non velit.","secretAnswer":"nulla integer pede","name":"Tenesha Schinner","dob":new Date(1964, 1, 21),"enrollmentDate":new Date(2014, 4, 17),"activationCode":"ITUL-XCVI-QMDS-OTBJ-IDUB"},
            {"activated":true,"secretQuestion":"Pellentesque ultrices mattis odio.","secretAnswer":"donec odio justo","name":"Rubin Brekke","dob":new Date(1958, 9, 20),"enrollmentDate":new Date(2014, 0, 10),"activationCode":"ZITR-SJIR-FDZQ-KOIZ-ZIEW"},
            {"activated":false,"secretQuestion":"In hac habitasse platea dictumst.","secretAnswer":"pharetra magna","name":"Clare Beatty","dob":new Date(1916, 7, 14),"enrollmentDate":new Date(2012, 0, 15),"activationCode":"TYSV-PDSC-MCJU-AERG-UMSJ"}];

            return original.concat(mocked);
    });