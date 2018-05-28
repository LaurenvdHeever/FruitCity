import Vue from 'vue'
import AppHeader from '@/components/AppHeader'

describe('AppHeader.vue', () => {
  it('should render correct contents', () => {
    const Constructor = Vue.extend(AppHeader)
    const vm = new Constructor().$mount()
    expect(vm.$el.querySelector('.container h1').textContent)
      .to.equal('FRUIT CITY')
  })
})
