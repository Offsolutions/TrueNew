(function() {
  var $,
    __indexOf = [].indexOf || function(item) { for (var i = 0, l = this.length; i < l; i++) { if (i in this && this[i] === item) return i; } return -1; };

  $ = jQuery;

  $.fn.validateCreditCard = function(callback, options) {
    var card, card_type, card_types, get_card_type, is_valid_length, is_valid_luhn, normalize, validate, validate_number, _i, _len, _ref, _ref1;
    card_types = [
      {
        name: 'amex',
        pattern: /^3[47]/,
        valid_length: [15]
      }, {
		name: 'diners_club_carte_blanche',
        pattern: /^(38|30[0-5])/,
        valid_length: [14]
      }, {
        name: 'diners_club_international',
        pattern: /^36/,
        valid_length: [14]
      }, {
        name: 'diners_club_enroute',
        pattern: /^(2149|2014)/,
        valid_length: [15]
      }, {
        name: 'jcb',
        pattern: /^(3088|3096|3112|3158|3337|35(2[8-9]|[3-8][0-9])|1800|2131)/,
        valid_length: [16]
      }, {
        name: 'laser',
        pattern: /^(6304|670[69]|6771)/,
        valid_length: [16, 17, 18, 19]
      }, {
        name: 'visa_electron',
        pattern: /^(4026|417500|4508|4844|491(3|7))/,
        valid_length: [16]
      }, {
        name: 'visa',
        pattern: /^4/,
        valid_length: [16]
      }, {
        name: 'mastercard',
        pattern: /^5[1-5]/,
        valid_length: [16]
      }, {
        name: 'rupay',
        pattern: /^(508[5-9]|6069|607|608[1-5]|65(2[1-9]|30)|6531[0-4])/,
        valid_length: [16]
      }, {
        name: 'discover',
        pattern: /^(6011([0234]|7[4789]|8[6-9]|9)|60622(12[6789]|1([3-9][0-9])|[2-8][0-9][0-9]|9([01][0-9]|2[0-5]))|64[4-9]|65)/,
        valid_length: [16]
      }, {
        name: 'maestro',
        pattern: /^(508(1(25|26|59|92)|227)|504(43[3547]|6(81|45)|7(75|53)|8(09|17|34|48|84)|9(73|93))|502260|60(3845|0206|3123|3741)|622018|67(0501|5964|7252))/,
        valid_length: [12, 13, 14, 15, 16, 17, 18, 19]
      }, {
        name: 'solo',
        pattern: /^(6334|6767)/,
        valid_length: [16, 18, 19]
      }, {
        name: 'switch',
        pattern: /^(633110|633312|633304|633303|633301|633300)/,
        valid_length: [16, 18, 19]
      }, {
        name: 'dankrot',
        pattern: /^5019/,
        valid_length: [16]
      }, {
        name: 'unionpay',
        pattern: /^(622|624|625|626|628)/,
        valid_length: [16]
      }

    ];
    if (options == null) {
      options = {};
    }

    if ((_ref = options.accept) == null) {
      options.accept = (function() {
        var _i, _len, _results;
        _results = [];
        for (_i = 0, _len = card_types.length; _i < _len; _i++) {
          card = card_types[_i];
          _results.push(card.name);
        }
        return _results;
      })();
    }
    _ref1 = options.accept;
    for (_i = 0, _len = _ref1.length; _i < _len; _i++) {
      card_type = _ref1[_i];
      if (__indexOf.call((function() {
        var _j, _len1, _results;
        _results = [];
        for (_j = 0, _len1 = card_types.length; _j < _len1; _j++) {
          card = card_types[_j];
          _results.push(card.name);
        }
        return _results;
      })(), card_type) < 0) {
        throw "Credit card type '" + card_type + "' is not supported";
      }
    }
    get_card_type = function(number) {
      var _j, _len1, _ref2;
      _ref2 = (function() {
        var _k, _len1, _ref2, _results;
        _results = [];
        for (_k = 0, _len1 = card_types.length; _k < _len1; _k++) {
          card = card_types[_k];
          if (_ref2 = card.name, __indexOf.call(options.accept, _ref2) >= 0) {
            _results.push(card);
          }
        }
        return _results;
      })();
      for (_j = 0, _len1 = _ref2.length; _j < _len1; _j++) {
        card_type = _ref2[_j];
        if (number.match(card_type.pattern)) {
          return card_type;
        }
      }
      return null;
    };
    is_valid_luhn = function(number) {
      var digit, n, sum, _j, _len1, _ref2;
      sum = 0;
      _ref2 = number.split('').reverse();
      for (n = _j = 0, _len1 = _ref2.length; _j < _len1; n = ++_j) {
        digit = _ref2[n];
        digit = +digit;
        if (n % 2) {
          digit *= 2;
          if (digit < 10) {
            sum += digit;
          } else {
            sum += digit - 9;
          }
        } else {
          sum += digit;
        }
      }
      return sum % 10 === 0;
    };
    is_valid_length = function(number, card_type) {
      var _ref2;
      return _ref2 = number.length, __indexOf.call(card_type.valid_length, _ref2) >= 0;
    };
    validate_number = function(number) {
      var length_valid, luhn_valid;
      card_type = get_card_type(number);
      luhn_valid = false;
      length_valid = false;
      if (card_type != null) {
        luhn_valid = is_valid_luhn(number);
        length_valid = is_valid_length(number, card_type);
      }
      return callback({
        card_type: card_type,
        luhn_valid: luhn_valid,
        length_valid: length_valid
      });
    };
    validate = function() {
      var number;
      number = normalize($(this).val());
      return validate_number(number);
    };
    normalize = function(number) {
      return number.replace(/[ -]/g, '');
    };
    this.bind('input', function() {
      $(this).unbind('keyup');
      return validate.call(this);
    });
    this.bind('keyup', function() {
      return validate.call(this);
    });
    if (this.length !== 0) {
      validate.call(this);
    }
    return this;
  };

}).call(this);

(function() {

  $(function() {
    $('.demo .numbers li').wrapInner('<a href="#"></a>').click(function(e) {
      e.preventDefault();
      return $('#ccnumber').val($(this).text()).trigger('input');
    });
    $('.vertical.maestro').hide().css({
      opacity: 0
    });
    return $('#ccnumber').validateCreditCard(function(result) {
      if (!(result.card_type != null)) {
        $('.cards li').removeClass('off');
        $('#ccnumber').removeClass('valid');
        $('.vertical.maestro').slideUp({
          duration: 200
        }).animate({
          opacity: 0
        }, {
          queue: false,
          duration: 200
        });
        return;
      }
      $('.cards li').addClass('off');
      $('.cards .' + result.card_type.name).removeClass('off');
      if (result.card_type.name === 'maestro') {
        $('.vertical.maestro').slideDown({
          duration: 200
        }).animate({
          opacity: 1
        }, {
          queue: false
        });
      } else {
        $('.vertical.maestro').slideUp({
          duration: 200
        }).animate({
          opacity: 0
        }, {
          queue: false,
          duration: 200
        });
      }
        
     
        if($(".cards li:not('.off')").length == 1){
            $('#ccType').val($(".cards li:not('.off')").attr('class'));
            $( "#ccType" ).trigger( "change" );
		
	      }
        //console.log(li_ccType.attr('class'));
        //console.log($(".cards li:not('.off')").length)
     
          

        
        
      if (result.length_valid && result.luhn_valid) {
        return $('#ccnumber').addClass('valid');
	 } 
	else {
       	return $('#ccnumber').removeClass('valid');
    	}
		
	

        

        
    });
  });

}).call(this);