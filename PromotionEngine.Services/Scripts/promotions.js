module.exports = {
  // 3 of A's for 130
  discountA: (callback, inputs) => {
    let retVal = 0;
    
    let key = 'A';

    let i = inputs.filter(x => x.key === key).length;

    if(i > 2) {
      retVal = Math.round(i / 3) * 20;
    }

    callback(null, retVal);

  },
  // 2 of B's for 45
  discountB: (callback, inputs) => {
    
    let retVal = 0;
    
    let key = 'B';
    let i = inputs.filter(x => x.key === key).length;

    if(i > 1) {
      let value = inputs.find(i => i.key === key).value;
      let j = i % 2 === 0 ? i : i - 1;
      retVal = j * value * 0.25;
    }

    callback(null, retVal);
    
  },
  discountC: (callback, inputs) => {
    let retVal = 0;
    
    let key1 = 'C';
    let key2 = 'D';

    let i = inputs.filter(x => x.key === key1 && x.key === key1).length;

    if(i > 0) {
      retVal = i * 5;
    }

    callback(null, retVal);

  },

}