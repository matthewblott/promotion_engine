// 3 of A's for 130

module.exports = (callback, inputs) => {
  let retVal = 0;
  
  let key = 'A';

  let i = inputs.filter(x => x.key === key).length;

  if(i > 2) {
    retVal = Math.round(i / 3) * 20;
  }

  callback(null, retVal);
  
}