<script setup>
defineProps({
  skills: Object,
});
</script>
<template>
  <section class="bg-light-tail-100 dark:bg-dark-navy-500 py-16">
    <div class="container mx-auto" v-motion :initial="{opacity:0,
    y:100,
    }"
    :visible="{opacity:1,
      y:0,
    }">
      <div class="grid grid-cols-8 md:grid-flow-col">
        <div
          class="flex items-center justify-center"
          v-for="skill in skills.data"
          :key="skill.id"
        >
          <img :src="skill.image" :alt="skill.name" class="lg:h-20" />
        </div>
      </div>
    </div>
  </section>
</template>