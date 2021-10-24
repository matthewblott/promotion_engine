// 3 of A's for 130

module.exports = (callback, inputs) => {
  let retVal = 0;
  
  let key = 'B';
  let i = inputs.filter(x => x.key === key).length;

  if(i > 1) {
    let value = inputs.find(i => i.key === key).value;
    let j = i % 2 === 0 ? i : i - 1;
    retVal = j * value * 0.25;
  }

  callback(null, retVal);
  
}