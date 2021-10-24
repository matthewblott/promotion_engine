function discount25PerCent(inputs) {

  let sku = 'B';
  let i = inputs.filter(x => x.sku === sku).length;

  if(i < 2) {
    return 0;
  }

  let value = inputs.find(i => i.sku === sku).value;
  let j = i % 2 === 0 ? i : i - 1;
  let discount = j * value * 0.25;

  return discount;

}