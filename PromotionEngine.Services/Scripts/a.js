// 3 As for 130, discount 20

module.exports = (callback, inputs) => {

  let retVal = 0;
  let key = 'A';
  let i = inputs.filter(x => x.key === key).length;

  if(i > 2) {
    retVal = Math.floor(i / 3) * 20;
  }

  callback(null, retVal);
  
}